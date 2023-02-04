using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstancer : GameObjectSingleton<TowerInstancer>
{
    private List<TowerDB> listTowerDB = null;

    public TowerUnit InstantiateTower(string _id)
    {
        return InstantiateTower(DB.Inst.GetTowerDB(_id));
    }

    public TowerUnit InstantiateTower(TowerDB _db)
    {
        if (_db == null)
            return null;

        var tower = Instantiate(Resources.Load<TowerUnit>(GetTowerDir(_db.res_id)));
        tower.InitTower(_db);
        return tower;
    }

    private string GetTowerDir(string _resId)
    {
        return string.Concat("TowerUnits/", _resId);
    }
}
