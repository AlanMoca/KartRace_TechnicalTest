namespace KartRace.Cars
{
    public interface IInput
    {
        float GetHorizontalDirection();
        float GetVerticalDirection();
        bool GetIfJumping();
        bool GetIfBoosting();

    }
}

