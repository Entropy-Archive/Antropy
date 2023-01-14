using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherScript : MonoBehaviour
{
  /// [0]Spring, [1]Summer, [2]Autumn, [3]Winter
  /// [0]sun, [1]rain, [2]overcast, [3]fog, [4] snow

  private GameManager gameManagerInstance;

  private void Awake()
  {
    gameManagerInstance = GameObject.Find("Game Manager").GetComponent<GameManager>();
  }
    /// <summary>
    /// Updates the current Weather
    /// </summary>
    /// <param name="currentSeason"> [0]Spring, [1]Summer, [2]Autumn, [3]Winter</param>
   public void UpdateWeather(int currentSeason) 
   {
     int weatherChance = Random.Range(0, 101);
     switch (currentSeason)
     {
        case 0:
          //higher probability of rain < overcast < sun
          if(weatherChance <= 50) 
          {
            gameManagerInstance.currentWeather = 1;
          }
          else if(weatherChance > 50 && weatherChance <= 70) 
          {
            gameManagerInstance.currentWeather = 2;
          }
          else 
          {
            gameManagerInstance.currentWeather = 0;
          }
          
          WeatherMultiplierUpdate(gameManagerInstance.currentWeather);
          break;

        case 1:
          //higher probability of sun < overcast < rain
          if (weatherChance <= 20)
          {
            gameManagerInstance.currentWeather = 1;
          }
          else if(weatherChance > 20 && weatherChance <= 40)
          {
            gameManagerInstance.currentWeather = 2;
          }
          else
          {
            gameManagerInstance.currentWeather = 0;
          }
          WeatherMultiplierUpdate(gameManagerInstance.currentWeather);
          break;

        case 2:
          //higher probability of rain < fog < sun
          if (weatherChance <= 20)
          {
            gameManagerInstance.currentWeather = 0;
          }
          else if (weatherChance > 20 && weatherChance <= 30)
          {
            gameManagerInstance.currentWeather = 3;
          }
          else if (weatherChance > 30 && weatherChance <= 40)
          {
            gameManagerInstance.currentWeather = 3;
          }
          else 
          {
            gameManagerInstance.currentWeather = 3;
          }
          WeatherMultiplierUpdate(gameManagerInstance.currentWeather);
          break;

        case 3:
        //DEATH
        gameManagerInstance.currentWeather = 4;
        WeatherMultiplierUpdate(gameManagerInstance.currentWeather);
        break;

        default:
          Debug.Log("Error with season assignment in  While Updating");
          break;
    }
  }

  /// <summary>
  /// Updates the current active multiplier
  /// </summary>
  /// <param name="weather"></param>
  public void WeatherMultiplierUpdate(int weather)
  {
    if(weather == gameManagerInstance.currentWeather) 
    {
      return;
    }

    if (weather == 0)
    {
      gameManagerInstance.weatherAcessMultiplier = gameManagerInstance.sunAccess;
      gameManagerInstance.weatherRegrowMultiplier = gameManagerInstance.sunRegrow;
    }
    else if (weather == 1)
    {
      gameManagerInstance.weatherAcessMultiplier = gameManagerInstance.rainAccess;
      gameManagerInstance.weatherRegrowMultiplier = gameManagerInstance.rainRegrow;
    }
    else if (weather == 2)
    {
      gameManagerInstance.weatherAcessMultiplier = gameManagerInstance.overcastAccess;
      gameManagerInstance.weatherRegrowMultiplier = gameManagerInstance.overcastRegrow;
    }
    else if (weather == 3)
    {
      gameManagerInstance.weatherAcessMultiplier = gameManagerInstance.fogAccess;
      gameManagerInstance.weatherRegrowMultiplier = gameManagerInstance.fogRegrow;
    }
    else if (weather == 4)
    {
      gameManagerInstance.weatherAcessMultiplier = gameManagerInstance.snowAccess;
      gameManagerInstance.weatherRegrowMultiplier = gameManagerInstance.snowRegrow;
    }
  }

  /// <summary>
  /// Returns the type integer to string name
  /// </summary>
  /// <param name="weatherType">[0]sun, [1]rain, [2]overcast, [3]fog, [4] snow</param>
  /// <returns></returns>
  public string WeatherName(int weatherType) 
  {
    switch (weatherType)
    {
      case 0:
        return "Sun";
      case 1:
        return "Rain";
      case 2:
        return "Overcast";
      case 3:
        return "Fog";
      case 4:
        return "Snow";

      default:
        return "InvalidWeather";
    }
  }
}
