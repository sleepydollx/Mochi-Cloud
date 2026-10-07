#include <iostream>
#include <string>

int main() {
    std::string input;

    while (true) {
        std::cout << "> ";
        
        if (!(std::cin >> input)) break;

        if (input == "mommy") {
            std::cout << "good boy~~~~\n";
        }
        else if (input == "exit" || input == "quit") {
            break;
        }
        else {
            std::cout << "unknown command: " << input << "\n";
        }
    }

    return 0;
}