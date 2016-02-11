using System.Collections.Generic;

namespace Tamagotchi.Objects
{
  public class Pet
  {
    private string _name;
    private int _food;
    private int _attention;
    private int _rest;
    private int _id;
    private static List<Pet> _pets = new List<Pet> {};
    private bool _status;

    public Pet(string name, int food = 100, int attention = 100, int rest = 100, bool status = true)
    {
      _name = name;
      _status = status;
      _food = food;
      _attention = attention;
      _rest = rest;
      _pets.Add(this);
      _id = _pets.Count;
    }
    public bool GetStatus()
    {
      int food = GetFood();
      int attention = GetAttention();
      int rest = GetRest();
      if (food <= 0 || attention <=0 || rest <=0){
        return false;
      }
      else
      {
        return true;
      }
    }
    public void SetStatus(bool status)
    {
      _status = status;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string name)
    {
      _name = name;
    }
    public int GetFood()
    {
      return _food;
    }
    public void SetFood(int food)
    {
      _food = food;
    }
    public int GetAttention()
    {
      return _attention;
    }
    public void SetAttention(int attention)
    {
      _attention = attention;
    }
    public int GetRest()
    {
      return _rest;
    }
    public void SetRest(int rest)
    {
      _rest = rest;
    }
    public static List<Pet> GetAll()
    {
      return _pets;
    }
    public int GetId()
    {
      return _id;
    }
    public static Pet Find(int id)
    {
      return _pets[id-1];
    }
    public static void TimePass()
    {
      List<Pet> pets = Pet.GetAll();
      foreach(Pet pet in pets)
      {
        int food = pet.GetFood();
        pet.SetFood(food - 10);
        int attention = pet.GetAttention();
        pet.SetAttention(attention - 10);
        int rest = pet.GetRest();
        pet.SetRest(rest - 10);
      }
    }

    public void FeedPet()
    {
      SetFood(_food + 10);
    }

    public void AttentionPet()
    {
      SetAttention(_attention + 10);
    }

    public void RestPet()
    {
      SetRest(_rest + 10);
    }

    public static void ClearAll()
    {
      _pets.Clear();
    }
  }
}
