namespace Human
{
    public class human
    {
        public string name;
        public int health;
        public int strength;
        public int dexterity;
        public int intelligence;

        public human(string n, int s = 3, int i = 3, int d = 3, int h = 100)
        {
            name = n;
            strength = s;
            intelligence = i;
            health = h;
            dexterity = d;

        }
        public human(string n)
        {
            name = n;
            strength = 3;
            intelligence = 3;
            health = 100;
            dexterity = 3;

        }
        public human()
        {
            name = "";
            strength = 3;
            intelligence = 3;
            health = 100;
            dexterity = 3;

        }
        public void attack(human h)
        {
            h.health -= this.strength * 5;

        }



    }




}