#include "AppClass.h"
void Application::InitVariables(void)
{
	////Change this to your name and email
	m_sProgrammer = "Alberto Bobadilla - labigm@rit.edu";
	vector3 v3Position(0.0f, 0.0f, 10.0f);
	vector3 v3Target = ZERO_V3;
	vector3 v3Upward = AXIS_Y;
	m_pCameraMngr->SetPositionTargetAndUpward(v3Position, v3Target, v3Upward);

	//Allocate the memory for the Meshes
	m_uMeshCount = 46;
	for (uint i = 0; i < m_uMeshCount; ++i)
	{
		MyMesh* pMesh = new MyMesh();
		m_pMesh.push_back(pMesh);
		m_pMesh[i]->GenerateCube(1.0f, C_WHITE);
	}
		
}
void Application::Update(void)
{
	//Update the system so it knows how much time has passed since the last call
	m_pSystem->Update();

	//Is the arcball active?
	ArcBall();

	//Is the first person camera active?
	CameraRotation();

	//Update Entity Manager
	m_pEntityMngr->Update();

	//Add objects to render list
	m_pEntityMngr->AddEntityToRenderList(-1, true);
}
void Application::Display(void)
{
	// Clear the screen
	ClearScreen();

	//Calculate the model, view and projection matrix
	matrix4 m4Projection = m_pCameraMngr->GetProjectionMatrix();
	matrix4 m4View = m_pCameraMngr->GetViewMatrix();

	//Get a timer
	static float fTimer = 0;	//store the new timer
	static uint uClock = m_pSystem->GenClock(); //generate a new clock for that timer

	/* The following method is just one way of doing this, another one would be using
	a single mesh to draw all positions */
	//Draw Meshes
	int i = 0;
	static float fHorizontal = -10.0f;
	static vector3 v3Position(fHorizontal, 0.0f, 0.0f);
	fTimer += static_cast<float>(m_pSystem->GetDeltaTime(uClock)); //get the delta time for that timer

	v3Position.x = fHorizontal + fTimer;
	matrix4 m4Position = glm::translate(vector3(0.0f, 0.0f, 0.0f)) * glm::translate(v3Position);

	//first row
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(3.0f, 0.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(4.0f, 0.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(6.0f, 0.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(7.0f, 0.0f, 0.0f))); ++i;

	//second row
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(0.0f, 1.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(2.0f, 1.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(8.0f, 1.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(10.0f, 1.0f, 0.0f))); ++i;

	//third row
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(0.0f, 2.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(2.0f, 2.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(3.0f, 2.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(4.0f, 2.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(5.0f, 2.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(6.0f, 2.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(7.0f, 2.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(8.0f, 2.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(10.0f, 2.0f, 0.0f))); ++i;

	//fourth row
	for (int j = 0; j < 11; ++j)
	{
		m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(j, 3.0f, 0.0f))); ++i;
	}

	//fifth row
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(1.0f, 4.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(2.0f, 4.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(4.0f, 4.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(5.0f, 4.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(6.0f, 4.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(8.0f, 4.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(9.0f, 4.0f, 0.0f))); ++i;

	//sixth row
	for (int z = 2; z < 9; ++z)
	{
		m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(z, 5.0f, 0.0f))); ++i;
	}

	//seventh row
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(3.0f, 6.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(7.0f, 6.0f, 0.0f))); ++i;

	//eight row
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(2.0f, 7.0f, 0.0f))); ++i;
	m_pMesh[i]->Render(m4Projection, m4View, glm::translate(m4Position, vector3(8.0f, 7.0f, 0.0f))); ++i;

	// draw a skybox
	m_pModelMngr->AddSkyboxToRenderList();

	//render list call
	m_uRenderCallCount = m_pModelMngr->Render();

	//clear the render list
	m_pModelMngr->ClearRenderList();

	//draw gui
	DrawGUI();
	
	//end the current frame (internally swaps the front and back buffers)
	m_pWindow->display();
}
void Application::Release(void)
{
	//Release meshes
	std::vector<MyMesh*> m_pMesh;
	int uSize = m_pMesh.size();
	for (int i = 0; i < uSize; ++i)
	{
		if (m_pMesh[i] != nullptr)
		{
			delete m_pMesh[i];
			m_pMesh[i] = nullptr;
		}
	}

	//release GUI
	ShutdownGUI();
}