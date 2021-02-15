
#include <iostream>
#include "Windows.h"

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
    std::cout << "Server started. Creating named pipe...\n";
    SetConsoleCtrlHandler(HandlerRoutine, true);
    
    
    HANDLE hNamedPipe = CreateNamedPipe(
        L"\\\\.\\pipe\\avast",
        PIPE_ACCESS_DUPLEX,
        PIPE_TYPE_BYTE,
        3,
        0,
        10000,
        0,
        NULL);

    bool isCon = false;
    std::cout << "Created. Waiting for connection...\n";
    do {
        isCon = ConnectNamedPipe(
            hNamedPipe,
            NULL);
    } while (!isCon);

    std::cout << "Connected. Reading message...\n";
    wchar_t buf[128];
    DWORD numBytesRead = 0;
    ReadFile(
        hNamedPipe,
        buf, // the data from the pipe will be put here
        127 * sizeof(wchar_t), // number of bytes allocated
        &numBytesRead, // this will store number of bytes actually read
        NULL // not using overlapped IO
    );
    int end = numBytesRead / sizeof(wchar_t);
    buf[end] = '\0'; // null terminate the string
    std::cout << "Message: " << buf << std::endl;

    CloseHandle(hNamedPipe);
    getchar();
}