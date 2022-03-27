#ifndef RECORDSFUNCTIONS_H_INCLUDED
#define RECORDSFUNCTIONS_H_INCLUDED
#include <iomanip>

const int COLS = 5;
const int ROWS = 5;

double data[ROWS][COLS];

double cols;
double rows;
double total = 0;
double average;
double highest;
double lowest;

double GetTotal(double [][COLS]);

double GetAverage(double [][COLS]);

double GetRowTotal(double [][COLS], int);

double GetColumnTotal(double [][COLS], int);

double GetHighest(double [][COLS], int&, int&);

double GetLowest(double [][COLS], int&, int&);

#endif // RECORDSFUNCTIONS_H_INCLUDED
