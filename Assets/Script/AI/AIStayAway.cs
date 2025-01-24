using UnityEngine;

public class AIStayAway : MobAI
{
    private Rigidbody2D monsterRB;
    private Transform playerPosition;

    public float distance;

    private Vector3 velocity = Vector3.zero;

    public AIStayAway(Rigidbody2D _monsterRB, Transform _playerPosition, float _moveSpeed) : base(_moveSpeed)
    {
        monsterRB = _monsterRB;
        playerPosition = _playerPosition;
    }
    public override void onNextTick()
    {
        if (playerPosition != null && monsterRB != null)
        {

            float deltaX = playerPosition.position.x - monsterRB.transform.position.x;
            float deltaY = playerPosition.position.y - monsterRB.transform.position.y;

            Vector2 movement = new Vector2(deltaX, deltaY);

            float currentDistance = Vector2.Distance(monsterRB.position, playerPosition.position);

            if (-0.1f < currentDistance && currentDistance < 0.1f)
            {
                monsterRB.linearVelocity = Vector2.zero;
            } else if (currentDistance < distance)
            {
                moveMonster(movement * -1);
            } else
            {
                moveMonster(movement);
            }

        }
        //implique qu'un des 2 soit mort   
    }

    private void moveMonster(Vector2 _movement)
    {
        _movement.Normalize();
        _movement = _movement * MoveSpeed * Time.deltaTime;

        monsterRB.linearVelocity = Vector3.SmoothDamp(monsterRB.linearVelocity, _movement, ref velocity, 0.05f);
    }
}



