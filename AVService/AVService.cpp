
#include <iostream>
#include "Windows.h"
#include <string>

#define BUFSIZE 128

//on closing
BOOL __stdcall HandlerRoutine(DWORD eventCode)
{
    switch (eventCode)
    {
    case CTRL_CLOSE_EVENT:
        // do your thing
        std::cout << "exiting\n";
        Sleep(1000);
        return FALSE;
        break;
    }

    return TRUE;
}



int main()
{
    setlocale(LC_ALL, "RU");
    std::cout << "Server started. Creating named pipe..." << std::endl;
    SetConsoleCtrlHandler(HandlerRoutine, true);
    
    HANDLE hNamedPipe = CreateNamedPipeW(
        L"\\\\.\\pipe\\antiv",
        PIPE_ACCESS_DUPLEX,
        PIPE_TYPE_BYTE,
        3,
        0,
        0,
        0,
        NULL);

        bool isCon = false;
        std::cout << "Waiting for connection..." << std::endl;
        do {
            isCon = ConnectNamedPipe(
                hNamedPipe,
                NULL);
        } while (!isCon);
        std::cout << "Connected. ";

    while (true) {
        std::cout << "Reading message..." << std::endl;
        byte buffer[BUFSIZE];
        DWORD numBytesRead = 0;
        ReadFile(
            hNamedPipe,
            buffer, // the data from the pipe will be put here
            BUFSIZE, //19 * sizeof(wchar_t), // number of bytes allocated
            &numBytesRead, // this will store number of bytes actually read
            NULL // not using overlapped IO
        );

        int end = numBytesRead;
        buffer[end] = '\0'; // null terminate the string

        std::cout << "Message: " << buffer << std::endl;
        std::string code = "";
        for (int i = 0; i < 4; i++)
            code += buffer[i];
        
        if (code._Equal("exit")) {
            std::cout << "Session has ended." << std::endl;
            break;
        }
        std::cout << "Writing message..." << std::endl;

        WriteFile(
            hNamedPipe,
            buffer,
            end,
            0,
            NULL
        );
    }
    CloseHandle(hNamedPipe);
}