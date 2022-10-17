using System;

namespace PE_Trees_APBG
{
    class Program
    {
        static void Main(string[] args)
        {
            //make all of the nodes
            TalentTreeNode magic = new TalentTreeNode("Magic", true);
            TalentTreeNode fireball = new TalentTreeNode("Fireball", true);
            TalentTreeNode crazyBigFireball = new TalentTreeNode("Crazy Big Fireball", false);
            TalentTreeNode tinyFireBalls = new TalentTreeNode("1000 Tiny Fireballs", true);
            TalentTreeNode magicArrow = new TalentTreeNode("Magic Arrow", false);
            TalentTreeNode iceArrow = new TalentTreeNode("Ice Arrow", false);
            TalentTreeNode explodingArrow = new TalentTreeNode("Exploding Arrow", false);

            //assign children to parent
            magic.Left = fireball;
            fireball.Left = crazyBigFireball;
            fireball.Right = tinyFireBalls;
            magic.Right = magicArrow;
            magicArrow.Left = iceArrow;
            magicArrow.Right = explodingArrow;

            //list all abilities
            Console.WriteLine("--Listing all abilities in the game--");
            magic.ListAllAbilities();

            //list all known abilities
            Console.WriteLine("\n--Listing all my known abilities--");
            magic.ListKnownAbilities();

            //list all unknown abilities
            Console.WriteLine("\n--Listing all my unknown abilities--");
            magic.ListPossibleAbilities();
        }
    }
}
