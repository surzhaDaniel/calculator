# Calculator Learning Project

## Overview
This project is a learning project that implements a mathematical expression calculator using various software design patterns and algorithms. It serves as a practical example of implementing clean architecture, design patterns, and mathematical expression parsing.

## Learning Objectives
- Implementation of the Shunting Yard Algorithm for expression parsing
- Understanding and applying design patterns (Strategy, Factory)
- Clean Architecture principles
- SOLID principles in practice
- Exception handling and input validation
- File I/O operations
- Unit testing

## Project Structure
```
Calculator/
├── Core/                    # Core calculator logic
│   ├── Calculator.cs       # Main calculator implementation
│   ├── Tokenizer.cs        # Expression tokenization
│   ├── ShuntingYardParser.cs # Infix to postfix conversion
│   └── PostfixEvaluator.cs # Postfix expression evaluation
├── Strategies/             # Input/Output strategies
│   ├── ConsoleMode.cs      # Console-based I/O
│   ├── FileMode.cs         # File-based I/O
│   └── StrategyFactory.cs  # Strategy creation
└── CalculatorAppUnitTests/ # Unit tests
```

## Key Learning Concepts

### 1. Design Patterns
- **Strategy Pattern**: Used for different input/output modes (Console and File)
- **Factory Pattern**: Creates appropriate strategies based on user input

### 2. Algorithms
- **Shunting Yard Algorithm**: Converts infix expressions to postfix notation
- **Postfix Evaluation**: Evaluates mathematical expressions in postfix notation
- **Tokenization**: Breaks down expressions into meaningful tokens

### 3. Clean Architecture
- Clear separation of concerns
- Core business logic isolated from infrastructure
- Interface-based design

## Features
- Support for basic mathematical operations (+, -, *, /)
- Parentheses handling
- Negative numbers support
- Two modes of operation:
  - Console mode: Interactive command-line interface
  - File mode: Read from input file, write to output file

## Getting Started

### Building and Running
1. Clone the repository
2. Open the solution in Visual Studio
3. Build the solution
4. Run the application

### Usage Examples

#### Console Mode
```
Choose the mode: 1 - console, 2 - file
1
Enter the expression: 
2 + 3 * (4 - 1)
Result: 11
```

#### File Mode
```
Choose the mode: 1 - console, 2 - file
2
Enter input file path:
input.txt
Enter output file path:
output.txt
```

## Testing
The project includes unit tests to demonstrate:
- Expression evaluation
- Strategy creation
- Input validation
- Error handling