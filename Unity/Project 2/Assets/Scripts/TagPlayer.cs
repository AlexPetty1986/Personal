using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TagStates
{
    Runner,
    Chaser,
    Morpher,
    Healer,
    Wraith
}

public class TagPlayer : Agent
{
    [SerializeField]
    private TagStates currentState = TagStates.Runner;

    public TagStates CurrentState
    {
        get { return currentState; }
    }

    private float countDown = 0f;

    public float visionDistance = 4f;

    public SpriteRenderer spriteRenderer;
    
    public int currentTagPlayer = 0;

    public List<Sprite> agentState = new List<Sprite>();

    protected override void CalcSteeringForces()
    {
        switch(currentState)
        {
            case TagStates.Chaser:
            case TagStates.Wraith:
            {
                //chase the nearest runner player
                TagPlayer targetPlayer = AgentManager.Instance.GetClosestTagPlayer(this);

                if(targetPlayer != null && targetPlayer.CurrentState != TagStates.Morpher && targetPlayer.CurrentState != TagStates.Chaser && targetPlayer.CurrentState != TagStates.Wraith)
                {
                    if(IsTouching(targetPlayer))
                    {
                        targetPlayer.Tag(targetPlayer);
                    }

                    else
                    {
                        Seek(targetPlayer.physicsObject.Position);
                    }
                }

                else
                {
                    Wander();
                }

                Separate(AgentManager.Instance.currentItPlayers);
                break;
            }

            case TagStates.Morpher:
            {
                //count to 0, then become chaser
                countDown -= Time.deltaTime;

                if(countDown <= 0f)
                {
                    float classChange = Random.Range(0.0f, 1.0f);

                    if (classChange > 0.2f)
                    {
                        StateTransition(TagStates.Chaser);
                    }
                    else
                    {
                        StateTransition(TagStates.Wraith);
                    }
                }
                break;
            }

            case TagStates.Runner:
            {
                if(AgentManager.Instance.currentItPlayers.Count > 0)
                {
                    //wander until spotted by chaser, then run
                    for(int i = 0; i < AgentManager.Instance.currentItPlayers.Count; i++)
                    {
                        float distToItPlayer = Vector3.SqrMagnitude(physicsObject.Position - AgentManager.Instance.currentItPlayers[i].physicsObject.Position);

                        if (distToItPlayer < Mathf.Pow(visionDistance, 2))
                        {
                            Flee(AgentManager.Instance.currentItPlayers[i].physicsObject.Position);
                        }

                        else
                        {
                            Wander();
                        }
                    }
                }

                else
                {
                    Wander();
                }
                Separate(AgentManager.Instance.tagPlayers);
                break;
            }

            case TagStates.Healer:
            {
                if (AgentManager.Instance.currentItPlayers.Count > 0)
                {
                    for (int i = 0; i < AgentManager.Instance.currentItPlayers.Count; i++)
                    {
                        float distToChaser = Vector3.SqrMagnitude(physicsObject.Position - AgentManager.Instance.currentItPlayers[i].physicsObject.Position);
                        TagPlayer targetCounter = AgentManager.Instance.FindCounter(this);

                        if (distToChaser < Mathf.Pow(visionDistance, 2) && AgentManager.Instance.currentItPlayers[i].CurrentState == TagStates.Chaser)
                        {
                            if (targetCounter != null && targetCounter.CurrentState == TagStates.Morpher)
                            {
                                if (IsTouching(targetCounter))
                                {
                                    targetCounter.Cure(targetCounter);
                                }

                                else
                                {
                                    Seek(targetCounter.physicsObject.Position);
                                }
                            }

                            else
                            {
                                Flee(AgentManager.Instance.currentItPlayers[i].physicsObject.Position);
                            }
                        }

                        else
                        {
                            if (targetCounter != null && targetCounter.CurrentState == TagStates.Morpher)
                            {
                                if (IsTouching(targetCounter))
                                {
                                    targetCounter.Cure(targetCounter);
                                }

                                else
                                {
                                    Seek(targetCounter.physicsObject.Position);
                                }
                            }

                            else
                            {
                                Wander();
                            }
                        }
                    }
                }

                else
                {
                    Wander();
                }
                Separate(AgentManager.Instance.tagPlayers);
                break;
            }
        }

        StayInBound(24f);
        if(currentState != TagStates.Wraith)
        {
            AvoidAllObstacles();
        }
    }

    public void StateTransition(TagStates newTagState)
    {
        currentState = newTagState;

        switch (currentState)
        {
            case TagStates.Chaser:
            {
                //do logic for becoming chaser
                spriteRenderer.sprite = agentState[0];
                physicsObject.useFriction = false;
                physicsObject.radius = 0.4f;
                break;
            }

            case TagStates.Morpher:
            {
                //do logic for becoming a counter
                spriteRenderer.sprite = agentState[1];
                countDown = AgentManager.Instance.countdownTime;
                physicsObject.useFriction = true;
                physicsObject.radius = 0.8f;
                AgentManager.Instance.currentItPlayers.Add(this);
                break;
            }

            case TagStates.Runner:
            {
                //transition from being counter to runner
                spriteRenderer.sprite = agentState[2];
                physicsObject.useFriction = false;
                break;
            }

            case TagStates.Healer:
            {
                //transition from being counter to healer
                spriteRenderer.sprite = agentState[3];
                physicsObject.useFriction = false;
                break;
            }

            case TagStates.Wraith:
            {
                //do logic for becoming wraith
                spriteRenderer.sprite = agentState[4];
                physicsObject.useFriction = false;
                physicsObject.radius = 0.4f;
                maxSpeed = 1f;
                maxForce = 1f;
                break;
            }
        }
    }

    public void Tag(TagPlayer targetPlayer)
    {
        StateTransition(TagStates.Morpher);
        physicsObject.radius = 1.0f;
        AgentManager.Instance.tagPlayers[targetPlayer.currentTagPlayer] = targetPlayer;
    }

    public void Cure(TagPlayer targetCounter)
    {
        float classChange = Random.Range(0.0f, 1.0f);
        if (classChange > 0.2f)
        {
            StateTransition(TagStates.Runner);
            physicsObject.radius = 0.4f;
        }

        else
        {
            StateTransition(TagStates.Healer);
            physicsObject.radius = 0.6f;
        }
        AgentManager.Instance.tagPlayers[targetCounter.currentTagPlayer] = targetCounter;
        AgentManager.Instance.currentItPlayers.RemoveAll(target => target.currentTagPlayer == targetCounter.currentTagPlayer);
    }

    private bool IsTouching(TagPlayer otherPlayer)
    {
        float sqrDistance = Vector3.SqrMagnitude(physicsObject.Position - otherPlayer.physicsObject.Position);
        float sqrRadii = Mathf.Pow(physicsObject.radius, 2) + Mathf.Pow(otherPlayer.physicsObject.radius, 2);

        return sqrDistance < sqrRadii;
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (this.CurrentState == TagStates.Morpher || this.CurrentState == TagStates.Chaser || this.CurrentState == TagStates.Wraith)
            {
                Cure(this);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (this.CurrentState == TagStates.Runner || this.CurrentState == TagStates.Healer)
            {
                Tag(this);
            }
        }
    }
}
