using System;
using System.Collections.Generic;

namespace LogicLayer.API;
interface ILogicAPI
{
    void AddClient(String firstName, String lastName, int id);
    void DeleteClient(int id);
    void UpdateClientsInfo(String firstName, String lastName, int id);
    int GetAllClientsNumber();
    String GetClientFirstName(int id);
    String GetClientLastName(int id);
    void AddClothes(int id, double price, String type);
    void UpdateClothesInfo(int id, double price, String type);
    void DeleteClothes(int id);
    int GetClothesNumber();
    String GetClothes(int id);
    int GetAllEventsNumber();
    int GetEventClientId(int id);
    int GetEventStateId(int id);
    DateTime GetEventTime(int id);
    void AddNewBatchEvent(int id, int stateId, int clientId, DateTime dateTime);
    void DeleteEvent(int id);
    void UpdateEvent(int id, int stateId, int clientId, DateTime dateTime);
    void AddStateWithCurrentCatalog(int id, Dictionary<int, int> inventory);
    int GetClothesState(int id, int stateId);
    Dictionary<int, int> GetAllStates(int stateId);
    void UpdateClothesStateInfo(int id, int newState, int stateId);
    void DeleteOneClothesState(int id, int stateId);
}