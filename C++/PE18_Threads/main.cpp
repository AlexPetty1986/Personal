#include "NumberPrinter.h"
#include "GamePlay.h"

void wrapper()
{
    NumberPrinter numPrint = NumberPrinter(5);

    vector<thread*> numThread;

    for (int i = 0; i < 50; i++)
    {
        //numPrint.Print();
        thread* printNum = new thread(&NumberPrinter::Print, numPrint);

        numThread.push_back(printNum);
    }

    for (int j = 0; j < numThread.size(); j++)
    {
        numThread[j]->join();
        delete numThread[j];
    }

    cout << endl;

    GamePlay models = GamePlay("Models");
    GamePlay physics = GamePlay("Physics");
    GamePlay graphics = GamePlay("Graphics");
    GamePlay pathfinding = GamePlay("Pathfinding");
    GamePlay dialogue = GamePlay("Dialogue");

    vector<thread*> gameThread;

    thread* modGame = new thread(&GamePlay::Update, models);
    thread* phyGame = new thread(&GamePlay::Update, physics);
    thread* graGame = new thread(&GamePlay::Update, graphics);
    thread* patGame = new thread(&GamePlay::Update, pathfinding);
    thread* diaGame = new thread(&GamePlay::Update, dialogue);

    gameThread.push_back(modGame);
    gameThread.push_back(phyGame);
    gameThread.push_back(graGame);
    gameThread.push_back(patGame);
    gameThread.push_back(diaGame);

    for (int j = 0; j < gameThread.size(); j++)
    {
        gameThread[j]->join();
        delete gameThread[j];
    }

    cout << "Update Complete! Time to Draw" << endl;
}

int main()
{
    wrapper();
    _CrtDumpMemoryLeaks();
    return 0;
}