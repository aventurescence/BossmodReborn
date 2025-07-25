﻿namespace BossMod.Endwalker.Alliance.A32Llymlaen;

class WindRose(BossModule module) : Components.SimpleAOEs(module, (uint)AID.WindRose, 12f);
class SeafoamSpiral(BossModule module) : Components.SimpleAOEs(module, (uint)AID.SeafoamSpiral, new AOEShapeDonut(6f, 70f));
class DeepDiveNormal(BossModule module) : Components.StackWithCastTargets(module, (uint)AID.DeepDiveNormal, 6f, 8);
class Stormwhorl(BossModule module) : Components.SimpleAOEs(module, (uint)AID.Stormwhorl, 6f);
class Stormwinds(BossModule module) : Components.SpreadFromCastTargets(module, (uint)AID.Stormwinds, 6f);
class Maelstrom(BossModule module) : Components.SimpleAOEs(module, (uint)AID.Maelstrom, 6f);
class Godsbane(BossModule module) : Components.CastCounter(module, (uint)AID.GodsbaneAOE);
class DeepDiveHardWater(BossModule module) : Components.StackWithCastTargets(module, (uint)AID.DeepDiveHardWater, 6f);

[ModuleInfo(BossModuleInfo.Maturity.Verified, Contributors = "Malediktus, LTS", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 962, NameID = 11299, SortOrder = 3, PlanLevel = 90)]
public class A32Llymlaen(WorldState ws, Actor primary) : BossModule(ws, primary, DefaultCenter, DefaultBounds)
{
    public const float CorridorHalfLength = 40f;
    public static readonly WPos DefaultCenter = new(default, -900f);
    public static readonly ArenaBoundsRect DefaultBounds = new(19f, 29f);
    public static readonly ArenaBoundsCustom EastCorridorBounds = BuildCorridorBounds(+1);
    public static readonly ArenaBoundsCustom WestCorridorBounds = BuildCorridorBounds(-1);

    public static ArenaBoundsCustom BuildCorridorBounds(float dx)
    {
        var corridor = new PolygonClipper.Operand(CurveApprox.Rect(DefaultBounds.Orientation, CorridorHalfLength, 10));
        var standard = new PolygonClipper.Operand(CurveApprox.Rect(DefaultBounds.Orientation, DefaultBounds.HalfWidth, DefaultBounds.HalfHeight).Select(o => new WDir(o.X - dx * CorridorHalfLength, o.Z)));
        return new(CorridorHalfLength, DefaultBounds.Clipper.Union(corridor, standard));
    }
}
