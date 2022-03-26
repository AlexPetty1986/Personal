using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Magic8Ball_AP
{
    //
    class MagicEightBall
    {
        //Private fields
        private String owner;
        private int timesShaken;
        private string[] responses;
        private Random rng;
        //Constructor method
        public MagicEightBall(String owner)
        {
            //Initialize variables
            this.owner = owner;
            this.timesShaken = 0;
            this.responses = new[]{"It is certain.", "Yes definitely.", "Signs point to yes.", "Outlook good.",
                "Cannot predict now", "Reply hazy, try again.", "Very doubtful.", "My sources say no."};
             this.rng = new Random();
        }
        //Shakes the ball and chooses a random response from the ball
        public string ShakeBall()
        {
            timesShaken++;
            return responses[rng.Next(responses.Length)];
        }
        //Reports how many times the ball has been shaken
        public string Report()
        {
            //If the user has shaken the ball between 1 to 3 times
            if (timesShaken >= 1 && timesShaken <=3)
            {
                return " > " + owner + " has shaken the ball " + timesShaken + " times.";
            }
            //If the user has shaken the ball four or more times
            else if(timesShaken >= 4)
            {
                return " > " + owner + " has shaken the ball " + timesShaken + " times." +
                    "  That's a lot of questions!";
            }
            //If the user has not shaken the ball yet
            return " > " + owner + " has not shaken the ball yet.";

        }
    }
}
