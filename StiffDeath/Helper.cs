namespace BetterHitReactions;
internal class RandomHelper
{
    internal static readonly Random rndm = new(DateTime.Now.Millisecond);

    public static float GetRandomFloat(float min, float max)
    {
        if (min > max)
            throw new ArgumentException("min must be less than or equal to max");

        return (float)(rndm.NextDouble() * (max - min) + min);
    }
}