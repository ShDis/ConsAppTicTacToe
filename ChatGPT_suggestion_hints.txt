using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';
        
        static void Main(string[] args)
        {
            InitBoard();
            DrawBoard();

            while (true)
            {
                Console.WriteLine("Player {0}'s turn. Enter row (1-3):", currentPlayer);
                int row = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Enter column (1-3):");
                int col = int.Parse(Console.ReadLine()) - 1;

                if (!IsValidMove(row, col))
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue;
                }

                MakeMove(row, col);
                DrawBoard();

                if (CheckWin())
                {
                    Console.WriteLine("Player {0} wins!", currentPlayer);
                    break;
                }

                if (CheckDraw())
                {
                    Console.WriteLine("Draw!");
                    break;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

            Console.ReadLine();
        }

        static void InitBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = '-';
                }
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("   1 2 3");
            Console.WriteLine("  -------");

            for (int row = 0; row < 3; row++)
            {
                Console.Write("{0} |", row + 1);

                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" {0}", board[row, col]);
                }

                Console.Write(" |\n");
            }

            Console.WriteLine("  -------");
        }

        static bool IsValidMove(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                return false;
            }

            if (board[row, col] != '-')
            {
                return false;
            }

            return true;
        }

        static void MakeMove(int row, int col)
        {
            board[row, col] = currentPlayer;
        }

        static bool CheckWin()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2] && board[row, 0] != '-')
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == board[1, col] && board[1, col] == board[2, col] && board[0, col] != '-')
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != '-')
            {
                return true;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0,2]!= '-')
{
return true;
}
return false;
    }

    static bool CheckDraw()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == '-')
                {
                    return false;
                }
            }
        }

        return true;
    }
}

В этом коде мы создали массив `board`, который представляет собой игровое поле размером 3 на 3. Мы также создали переменную `currentPlayer`, которая указывает, чей ход сейчас.

В функции `Main` мы вызываем функцию `InitBoard`, чтобы заполнить поле дефисами (которые представляют пустые клетки), а затем вызываем функцию `DrawBoard`, чтобы отрисовать поле в консоли.

Затем мы создаем бесконечный цикл, который будет продолжаться до тех пор, пока игрок не победит или не будет ничья. В каждой итерации цикла мы запрашиваем у текущего игрока строку и столбец, куда он хочет сделать ход. Затем мы проверяем, является ли этот ход допустимым, используя функцию `IsValidMove`. Если ход недопустимый, мы выводим сообщение об ошибке и продолжаем цикл. Если ход допустимый, мы делаем его, используя функцию `MakeMove`, отрисовываем поле с помощью функции `DrawBoard` и проверяем, победил ли игрок или наступила ничья, используя функции `CheckWin` и `CheckDraw`.

Если игрок победил, мы выводим сообщение о победе и завершаем цикл. Если наступила ничья, мы выводим сообщение о ничье и завершаем цикл.

Функция `IsValidMove` проверяет, является ли данный ход допустимым. Ход допустим, если он не выходит за границы поля и не занят другим игроком.

Функция `MakeMove` делает ход на поле, используя текущего игрока (`currentPlayer`).

Функция `CheckWin` проверяет, выиграл ли текущий игрок. Для этого мы проверяем все возможные победные комбинации: строки, столбцы и диагонали.

Функция `CheckDraw` проверяет, наступила ли ничья. Если на поле остались только дефисы, то это означает, что ничья.

Чтобы подсветить ходы, мы можем использовать ANSI Escape-коды. Например, чтобы подсветить ход крестиком, мы можем использовать следующий код:

```csharp
Console.ForegroundColor = ConsoleColor.Red

Чтобы сбросить цвет обратно на стандартный, мы можем использовать следующий код:
Console.ResetColor();

Чтобы подсветить клетку, мы можем использовать следующий код:
Console.Write("[");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("X");
Console.ResetColor();
Console.Write("]");

Этот код напечатает клетку с крестиком, подсвеченным красным цветом.

Чтобы подсветить все клетки, занятые текущим игроком, мы можем использовать циклы:
for (int row = 0; row < 3; row++)
{
    for (int col = 0; col < 3; col++)
    {
        if (board[row, col] == currentPlayer)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(board[row, col]);
            Console.ResetColor();
            Console.Write("]");
        }
        else
        {
            Console.Write("[" + board[row, col] + "]");
        }
    }
    Console.WriteLine();
}

Этот код отрисует поле с подсвеченными клетками, занятыми текущим игроком.

Мы можем добавить этот код в функцию DrawBoard, чтобы подсвечивать ходы при отрисовке поля:

static void DrawBoard()
{
    Console.Clear();
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (board[row, col] == currentPlayer)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(board[row, col]);
                Console.ResetColor();
                Console.Write("]");
            }
            else
            {
                Console.Write("[" + board[row, col] + "]");
            }
        }
        Console.WriteLine();
    }
}

Теперь при отрисовке поля будут подсвечены ходы текущего игрока.

Шаг 7. Реализация проверки победной комбинации

После каждого хода необходимо проверить, не выиграл ли текущий игрок. Для этого нужно проверить все возможные комбинации из трёх клеток.

Добавим функцию CheckWin для проверки победной комбинации. Функция принимает текущую доску и текущего игрока в качестве параметров и возвращает true, если текущий игрок выиграл, и false в противном случае.

static bool CheckWin(char[,] board, char player)
{
    // Проверка горизонтальных линий
    for (int row = 0; row < 3; row++)
    {
        if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
        {
            return true;
        }
    }

    // Проверка вертикальных линий
    for (int col = 0; col < 3; col++)
    {
        if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
        {
            return true;
        }
    }

    // Проверка диагонали \
    if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
    {
        return true;
    }

    // Проверка диагонали /
    if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
    {
        return true;
    }

    // Если ни одна из комбинаций не выполнилась, то игрок не выиграл
    return false;
}

Эта функция проверяет все возможные комбинации из трёх клеток на доске. Если все три клетки содержат символ текущего игрока, то текущий игрок выиграл.

Теперь, после каждого хода, мы можем вызвать функцию CheckWin и проверить, выиграл ли текущий игрок:

if (CheckWin(board, currentPlayer))
{
    Console.WriteLine("Победил игрок " + currentPlayer);
    Console.ReadLine();
    return;
}

Если функция вернет true, то мы сообщим о победе текущего игрока и завершим игру.

Шаг 8. Реализация проверки на ничью

Ничья наступает, когда все клетки на доске заняты, и никто не выиграл. Для проверки на ничью добавим функцию CheckDraw, которая проверяет, заняты ли все клетки на доске.

static bool CheckDraw(char[,] board)
{
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (board[row, col] == '-')
            {
                return false;
            }
        }
     }
}

Здесь мы проверяем все клетки на доске. Если мы находим любую клетку со значением '-', то игра еще не закончена, и функция возвращает false. Если все клетки заняты, то функция возвращает true.

Добавим вызов функции CheckDraw после каждого хода, чтобы проверить, не наступила ли ничья:

if (CheckDraw(board))
{
    Console.WriteLine("Ничья!");
    Console.ReadLine();
    return;
}

Если функция вернет true, то мы сообщим об этом и завершим игру.

Шаг 9. Дополнительная функциональность: подсветка ходов

Чтобы облегчить игрокам процесс игры, можно добавить подсветку ходов на доске. Для этого нам нужно будет изменить функцию DrawBoard и добавить функцию HighlightCell, которая будет подсвечивать клетку с заданными координатами.

static void DrawBoard(char[,] board, int highlightRow = -1, int highlightCol = -1)
{
    Console.Clear();
    Console.WriteLine("  0 1 2");

    for (int row = 0; row < 3; row++)
    {
        Console.Write(row + " ");
        for (int col = 0; col < 3; col++)
        {
            if (row == highlightRow && col == highlightCol)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(board[row, col] + " ");
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}

Функция HighlightCell будет просто вызывать DrawBoard с заданными параметрами:

static void HighlightCell(char[,] board, int row, int col)
{
    DrawBoard(board, row, col);
    Thread.Sleep(500);
}

Эта функция будет подсвечивать клетку с заданными координатами на полсекунды, а затем возвращаться к нормальному отображению доски.

Теперь мы можем использовать функцию HighlightCell для подсветки ходов игроков. Например, в функции GetPlayerMove мы можем добавить вызов этой функции после того, как игрок сделал ход:

board[row, col] = currentPlayer;
HighlightCell(board, row, col);

Таким образом, после каждого хода игроков будет видеть подсвеченную клетку, где был сделан ход.

Шаг 10. Запуск игры

Теперь, когда все функции реализованы, мы можем запустить игру в функции Main. Запустим бесконечный цикл, в котором будут ходить игроки до тех пор, пока игроки не решат завершить игру.

static void Main(string[] args)
{
    while (true)
    {
        char[,] board = {
            { '-', '-', '-' },
            { '-', '-', '-'


В цикле мы сначала выводим доску на экран с помощью функции DrawBoard, затем получаем ход первого игрока с помощью функции GetPlayerMove и проверяем, не завершилась ли игра с его ходом. Если игра завершилась, мы выходим из цикла и завершаем программу.

Затем мы делаем то же самое для второго игрока. Если игра закончилась после хода второго игрока, мы также выходим из цикла и завершаем программу.

Полный код программы:

using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                char[,] board = {
                    { '-', '-', '-' },
                    { '-', '-', '-' },
                    { '-', '-', '-' }
                };
                char currentPlayer = 'X';

                while (true)
                {
                    DrawBoard(board);

                    Console.WriteLine($"Ход игрока {currentPlayer}:");
                    int[] move = GetPlayerMove(board);
                    int row = move[0];
                    int col = move[1];

                    board[row, col] = currentPlayer;
                    HighlightCell(board, row, col);

                    if (CheckWin(board, currentPlayer))
                    {
                        DrawBoard(board);
                        Console.WriteLine($"Игрок {currentPlayer} победил!");
                        Console.ReadLine();
                        break;
                    }

                    if (CheckDraw(board))
                    {
                        DrawBoard(board);
                        Console.WriteLine("Ничья!");
                        Console.ReadLine();
                        break;
                    }

                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }

                Console.WriteLine("Хотите сыграть еще раз? (Y/N)");
                string answer = Console.ReadLine().ToUpper();
                if (answer != "Y")
                {
                    break;
                }
            }
        }

        static void DrawBoard(char[,] board, int highlightRow = -1, int highlightCol = -1)
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");

            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < 3; col++)
                {
                    if (row == highlightRow && col == highlightCol)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(board[row, col] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void HighlightCell(char[,] board, int row, int col)
        {
            DrawBoard(board, row, col);
            Thread.Sleep(500);
        }

        static int[] GetPlayerMove(char[,] board)
        {
            int row, col;
            while (true)
            {
                Console.Write("Введите строку (0-2): ");
                row = int.Parse(Console.ReadLine());
                Console.Write("Введите столбец (0-2): ");
                col = int.Parse(Console.ReadLine());
                if (row >= 0 && row <= 2 && col >= 0 && col <= 2 && board[row, col] == '-')
                {
                    return new int[] { row, col };
                }
                else
                {
                    Console.WriteLine("Некорректный ход. Попробуйте еще раз.");
                }
            }
        }

        static bool CheckWin(char[,] board, char player)
{
// Проверяем строки
for (int row = 0; row < 3; row++)
{
if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
{
return true;
}
}

        // Проверяем столбцы
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
            {
                return true;
            }
        }

        // Проверяем диагонали
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            return true;
        }
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
        {
            return true;
        }

        return false;
    }

    static bool CheckDraw(char[,] board)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == '-')
                {
                    return false;
                }
            }
        }
        return true;
    }
}


Обратите внимание на использование функции `HighlightCell`, которая подсвечивает клетку, в которую сделал ход игрок. Она вызывается перед изменением содержимого клетки и принимает координаты клетки для подсветки. Также обратите внимание на использование функции `Thread.Sleep` для задержки вывода подсвеченной клетки на экране.

В функции `CheckWin` мы проверяем все возможные комбинации для выигрыша. Если в одной из комбинаций содержатся три клетки с символом игрока, мы возвращаем `true`. В функции `CheckDraw` мы проверяем, остались ли еще пустые клетки на доске. Если пустых клеток нет, то возвращаем `true`, что означает ничью.

Код полностью готов и должен успешно запускаться в среде разработки C# или в консоли. Если возникнут какие-либо вопросы, не стесняйтесь задавать их.
