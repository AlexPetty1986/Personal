using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Trees_APBG
{
    class TalentTreeNode
    {
        //fields
        private string ability;
        private bool learned;
        private TalentTreeNode left;
        private TalentTreeNode right;

        //constructor
        public TalentTreeNode(string ability, bool learned)
        {
            this.ability = ability;
            this.learned = learned;
            this.left = null;
            this.right = null;
        }

        //getters and setters
        public TalentTreeNode Left
        {
            get { return left; }

            set { left = value; }
        }

        public TalentTreeNode Right
        {
            get { return right; }

            set { right = value; }
        }

        //method to list all abilities
        public void ListAllAbilities()
        {
            //If ability to the left is not null
            if (this.Left != null)
            {
                this.Left.ListAllAbilities();
            }

            //Print ability
            Console.WriteLine(this.ability);

            //If ability to the right is not null
            if (this.Right != null)
            {
                this.Right.ListAllAbilities();
            }
        }

        //method to list all known abilities
        public void ListKnownAbilities()
        {
            //Print ability
            Console.WriteLine("Known ability: " + this.ability);

            //If the ability to the left is not null and is known
            if (this.Left != null && this.Left.learned)
            {
                this.Left.ListKnownAbilities();
            }

            //If the ability to the right is not null and is known
            if (this.Right != null && this.Right.learned)
            {
                this.Right.ListKnownAbilities();
            }

        }

        //method to list all unknown abilities
        public void ListPossibleAbilities()
        {
            //if the parent ability is known and the ability to the left is not null
            if (this.learned && this.Left != null)
            {
                this.Left.ListPossibleAbilities();
            }

            //if the ability is not known yet
            if (!learned)
            {
                //Print ability
                Console.WriteLine("Possible ability: " + this.ability);
            }

            //if the parent ability is known and the ability to the right is not null
            if (this.learned && this.Right != null)
            {
                this.Right.ListPossibleAbilities();
            }
        }
    }
}
