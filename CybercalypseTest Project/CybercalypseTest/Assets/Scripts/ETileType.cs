

// 생성할 타입의 종류
public enum ETileType
{
    Flat, Uphill, Downhill, Foothold, Ceiling, Wall, Stuff, Empty, Portal,
    MonsterSponer, PlayerSponer, ItemSponer, Decorator, Water, COUNT
}
// 순서대로 평지, 오르막길, 내리막길, 발판, 천장, 벽, 쓸모없는 공간, 플레이어가 다닐 수 있는 빈 공간, 포탈
// 몬스터 스포너, 플레이어 스포너, 아이템 스포너, 데코레이터, 물, TileType개수