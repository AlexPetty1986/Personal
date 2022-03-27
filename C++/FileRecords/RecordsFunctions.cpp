#include "RecordsFunctions.h"

void AddStudent(fstream* fileHandler)
{
    StudentRecord temp;

    if(fileHandler)
    {
        cout << "Enter Student Name: ";
        cin.getline(temp.name,29);
        cout << "Enter Student GPA: ";
        cin >> temp.gpa;
        cout << "Enter Student ID: ";
        cin >> temp.id;

        fileHandler->write((char*)(&temp),sizeof(temp));
    }
    else
    {
        cout << "File not opened" << endl;
    }
}
int DisplayAllStudents(fstream* fileHandler)
{
    StudentRecord temp;
    int count = 0;

    cout << fixed << showpoint << setprecision(2);
    if(fileHandler)
    {
        fileHandler->read((char*)(&temp),sizeof(temp));
        while(!fileHandler->eof())
        {
            count++;
            cout << temp.name << endl;
            cout << temp.gpa << endl;
            cout << temp.id << endl;
            fileHandler->read((char*)(&temp),sizeof(temp));
        }
    }
    else
    {
        cout << "File not opened" << endl;
    }

    return count;
}
StudentRecord*GetStudentRecord(fstream* fileHandler, int numStudents)
{
    StudentRecord*temp = new StudentRecord;
    int recNum;

    if(fileHandler)
    {
        cout << "Which item would you like to display?: ";
        cin >> recNum;

        while(recNum < 1 || recNum > numStudents)
        {
            cout << "Wrong record number" << endl;
            cout << "Which item would you like to display?: ";
            cin >> recNum;
        }

        fileHandler->seekg((recNum-1)*sizeof(StudentRecord), ios::beg);
        fileHandler->read((char*)(temp),sizeof(*temp));
    }
    else
    {
        cout << "File not opened" << endl;
        delete temp;
        temp = nullptr;
    }

    return temp;
}
