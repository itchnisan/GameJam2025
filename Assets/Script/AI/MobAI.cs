public abstract class MobAI
{
    private float moveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public MobAI(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
    }

    public abstract void onNextTick();
}