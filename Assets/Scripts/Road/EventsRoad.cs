using System;

public static class EventsRoad
{
    public static event Action<RoadChunk> HitTrigger;
    public static void OnHitTrigger(RoadChunk chunk) => HitTrigger?.Invoke(chunk);

    public static event Action<EnemyCar> EnemyHitTrigger;
    public static void OnEnemyHitTrigger(EnemyCar car) => EnemyHitTrigger?.Invoke(car);
}
