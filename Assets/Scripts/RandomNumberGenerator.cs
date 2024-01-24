using Random = System.Random;

public abstract class RandomNumberGenerator
{
    public static int RandomNumber(int value, int valueSecond,bool isTwoNumber)
    {
        Random random = new Random();
            
        int numberBonuses;
            
        if (isTwoNumber)
            numberBonuses = random.Next(2) == 0 ? value : valueSecond;
        else
            numberBonuses = random.Next(value, valueSecond);
            
        return numberBonuses;
    }
}
