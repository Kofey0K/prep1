#pragma once
#include <iostream>
#include <string>

void(*TrafficOverloadHandler)(std::string message);

void DisplayMessage(std::string message) {
	std::cout << message << "\n";
}
class Lib
{
private:
	int Tariff;
	float account, price, speed, megabytes;
public:
	Lib(int choose) {
		account = 0;
		Set_Values(choose);
	}
	Lib(int choose, float money)
	{
		Set_Values(choose);
		account = money;
	}
    void Set_Values(int choose)
    {
        switch (choose)
        {
        case 1:
            Tariff = choose;
            speed = 30;
            megabytes = 4000;
            price = 60;
            break;
        case 2:
            Tariff = choose;
            speed = 30;
            megabytes = 8000;
            price = 80;
            break;
        case 3:
            Tariff = choose;
            speed = 60;
            megabytes = 12000;
            price = 100;
            break;
        case 4:
            Tariff = choose;
            speed = 60;
            megabytes = 16000;
            price = 120;
            break;
        default:
            std::cout << "The chosen tariff is missing." << "\n";
            break;
        }
    }
    void Choose_Tariff(int choose)
    {
        Set_Values(choose);
        account -= 10;
    }
    void AddMoney(float money)
    {
        account += money;
    }
    void Check()
    {
        std::cout<<"You have " << account << " left on your account. Megabytes left: " << megabytes<<"\n";
    }
    void UseInternet(double hours)
    {
        if (hours > 0)
        {
            for (double i = 0; i < hours; i += 0.1)
            {
                megabytes -= speed * 2.5;
                if (megabytes <= 0)
                {
                    TrafficOverloadHandler = DisplayMessage;
                    TrafficOverloadHandler("You have no megabytes left!");
                    megabytes = 0;
                    return;
                }
            }
        }
    }
    void NextDay()
    {
        account -= price / 30;
        if (account < 0) { megabytes = 0; }
    }
    
};

