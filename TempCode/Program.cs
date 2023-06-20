// Programmers Lv3 이중우선순위큐 문제 https://school.programmers.co.kr/learn/courses/30/lessons/42628

/*DualPriorityQueue solver = new DualPriorityQueue();

string[] operations = { "I -45", "I 653", "D 1", "I -642", "I 45", "I 97", "D 1", "D -1", "I 333" };

int[] answer = solver.solution(operations);
Console.WriteLine("answer: [" + answer[0] + ", " + answer[1] + "]");*/


// Programmers Lv3 깊이/너비 우선 탐색 문제 https://school.programmers.co.kr/learn/courses/30/lessons/43162

Solution solver = new Solution();

int n = 3;
int[,] computers = { { 1, 1, 0 }, { 1, 1, 0 }, { 0, 0, 1 } };

int answer = solver.solution(n, computers);
Console.WriteLine("answer: " + answer);