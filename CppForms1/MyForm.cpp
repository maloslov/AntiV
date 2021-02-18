#include "MyForm.h"
#include <Windows.h>
using namespace Forma;  // Название проекта

[STAThreadAttribute]
void Main(array<String^>^ args) {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Forma::MyForm form;
	Application::Run(% form);
}
