using UnityEngine;

public class AIRun : MobAI
{
    private Rigidbody2D monsterRB;
    private Transform playerPosition;

    private Vector3 velocity = Vector3.zero;

    public AIRun(Rigidbody2D _monsterRB, Transform _playerPosition, float _moveSpeed) : base(_moveSpeed)
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

            moveMonster(new Vector2(deltaX, deltaY));
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



