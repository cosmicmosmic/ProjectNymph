using GoogleSheet;
using GameType;
using System;

public abstract class BaseDB
{
    public abstract void OverwriteSheetDB(ITable _iTable);
    //-> json으로변환해서 다시 클래스로변환하면 필드명만 같으면 함수 하나로 자동으로 될듯
}

[Serializable]
public class MonsterDB : BaseDB
{
    public string id;
    public string res_id;
    public long health_point;
    public long defense_point;
    public float move_speed;

    public override void OverwriteSheetDB(ITable _iTable)
    {
        var sheetDB = (SheetData.MonsterDB)_iTable;

        id = sheetDB.id;
        res_id = sheetDB.res_id;
        health_point = sheetDB.health_point;
        defense_point = sheetDB.defense_point;
        move_speed = sheetDB.move_speed;
    }
}

[Serializable]
public class TowerDB : BaseDB
{
    public string id;
    public string res_id;
    public string attack_id;

    public long attack_point;//공격력
    public float attack_delay;//딜레이
    public float range;//사거리

    public override void OverwriteSheetDB(ITable _iTable)
    {
        var sheetDB = (SheetData.TowerDB)_iTable;

        id = sheetDB.id;
        res_id = sheetDB.res_id;
        attack_id = sheetDB.attack_id;

        attack_point = sheetDB.attack_point;
        attack_delay = sheetDB.attack_delay;
        range = sheetDB.range;
    }
}

[Serializable]
public class AttackDB : BaseDB
{
    public string id;
    public string res_id;

    public E_AttackType attack_type;

    public long attack_point;
    public float bullet_speed;

    public override void OverwriteSheetDB(ITable _iTable)
    {
        var sheetDB = (SheetData.AttackDB)_iTable;

        id = sheetDB.id;
        res_id = sheetDB.res_id;

        attack_type = (E_AttackType)Enum.Parse(typeof(E_AttackType), sheetDB.attack_type, true);

        attack_point = sheetDB.attack_point;
        bullet_speed = sheetDB.bullet_speed;
    }
}

[Serializable]
public class WaveDB : BaseDB
{
    public string id;
    public string[] monsters;

    public override void OverwriteSheetDB(ITable _iTable)
    {
        var sheetDB = (SheetData.WaveDB)_iTable;

        id = sheetDB.id;
        monsters = sheetDB.monsters.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }
}

[Serializable]
public class StageDB : BaseDB
{
    public string id;
    public string[] wave_list;

    public override void OverwriteSheetDB(ITable _iTable)
    {
        var sheetDB = (SheetData.StageDB)_iTable;

        id = sheetDB.id;
        wave_list = sheetDB.wave_list.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }
}
