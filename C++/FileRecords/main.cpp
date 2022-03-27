#include "RecordsFunctions.h"

using namespace std;

int main()
{
    int numberStudents;

    StudentRecord* student = nullptr;

    fstream* studentFile = new fstream("studentrecords.dat", ios::app | ios::binary);
    AddStudent(studentFile);

    studentFile->close();
    delete studentFile;
    studentFile = nullptr;

    studentFile = new fstream("studentrecords.dat", ios::in | ios::binary);
    numberStudents = DisplayAllStudents(studentFile);

    studentFile->close();
    delete studentFile;
    studentFile = nullptr;

    studentFile = new fstream("studentrecords.dat", ios::in | ios::binary);
    student = GetStudentRecord(studentFile, numberStudents);

    studentFile->close();
    delete studentFile;
    studentFile = nullptr;

    if(student)
    {
        cout << student->name << endl;
        cout << student->gpa << endl;
        cout << student->id << endl;
        delete student;
        student = nullptr;
    }
    else
    {
        cout << "No Record Found" << endl;
    }

    return 0;
}
