public class StartWithStayAway : MobMovement
{
    public AIStayAway ai;

    public float beginDistance;

    public float Distance
    {
        get { return ai.distance; }
        set { ai.distance = value; }
    }

    public StartWithStayAway() : base((mobRB, playerPosition, moveSpeed) =>
    {
        AIStayAway ai = new AIStayAway(mobRB, playerPosition, moveSpeed);
        return ai;
    })
    {

    }

    void Start()
    {
       ai = (AIStayAway) base.baseStart();
        ai.distance = beginDistance;
    }
}