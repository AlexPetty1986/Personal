#ifndef RECORDSFUNCTIONS_H_INCLUDED
#define RECORDSFUNCTIONS_H_INCLUDED
#include <iostream>
#include <fstream>
#include <cctype>
#include <string>
#include <iomanip>

using namespace std;

struct StudentRecord
{
    char name[30];
    int id;
    double gpa;
};

void AddStudent(fstream* fileHandler);
int DisplayAllStudents(fstream* fileHandler);
StudentRecord*GetStudentRecord(fstream* fileHandler, int numStudents);

#endif // RECORDSFUNCTIONS_H_INCLUDED
