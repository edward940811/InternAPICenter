using ESHClouds.ApiCenter.StoreHouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESHClouds.ApiCenter.Service
{
    public interface IBulletineService
    {
        List<Bulletine> getTodoList();

        Bulletine GetById(int id);
        string addTodoItem(Bulletine bulletine);
        string updateTodoItem(Bulletine bulletine);
    }
}
