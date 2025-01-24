using UnityEngine;

public class startWithRun : MobMovement
{

    public startWithRun() : base( (mobRB , playerPosition, moveSpeed) =>
    {
        return new AIRun(mobRB, playerPosition, moveSpeed);
    })
    {

    }

    void Start() { 
        base.baseStart();
        
    }
}