#include<iostream>
#include<fstream>


using namespace std;


struct wallSquare
{
	bool top = false;
	bool bottom = false;
	bool left = false;
	bool right = false;

	int holewall = 0;
};


struct board
{
	int theBoard[6][6] = { 0 };
	bool operator==(board righside)
	{
		for (int col = 0; col < 6; col++)
		{
			for (int row = 0; row < 6; row++)
			{
				if (this->theBoard[row][col] != righside.theBoard[row][col])
				{
					return false;
				}
			}
		}
		return true;
	}
};

class MarbleBoard
{
private:

	int size;
	int ballCount;
	int wallCount;
	board boardstack[100];
	wallSquare walls[6][6];

	int bestSolution = INT_MAX;
public:
	MarbleBoard()
	{
		int board = 0;
		int wall = 0;
		int size = 0;
		int ballCount = 0;
		int wallcount = 0;

	}
	void setSize(int size, int ballCount, int wallCount)
	{
		this->size = size;
		this->ballCount = ballCount;
		this->wallCount = wallCount;
	}
	void addwall(int r1, int c1, int r2, int c2)
	{
		if (r1 == r2)
		{
			if (c1 < c2)
			{
				walls[r1][c1].right = true;
				walls[r2][c2].left = true;

			}
			else {
				walls[r1][c1].left = true;
				walls[r2][c2].right = true;
			}
		}
		else {
			if (r1 < r2)
			{
				walls[r1][c1].bottom = true;
				walls[r2][c2].top = true;
			}
			else {
				walls[r1][c1].top = true;
				walls[r2][c2].bottom = true;
			}

		}

	}
	void addBall(int r, int c, int ball)
	{
		boardstack[0].theBoard[r][c] = ball;
	}
	bool isSolved(int layer)
	{
		for (int row = 0; row < 6; row++)
		{
			for (int col = 0; col < 6; col++)
			{
				if (boardstack[layer].theBoard[row][col] != 0)
				{
					return false;
				}
			}
		}
		return true;
	}
	bool seen(board tempboard, int layer)
	{
		for (int curlayer = layer; curlayer >= 0; curlayer--)
		{
			if (tempboard == boardstack[curlayer])
			{
				return true;
			}
		}return false;
	}


	void Solve(int layer)
	{

		if (layer >= bestSolution)
		{
			return;
		}
		if (isSolved(layer))
		{
			bestSolution = layer;
			return;
		}
		board tempboard = boardstack[layer];

		if (moveright(tempboard)) {

			if (!seen(tempboard, layer))
			{
				boardstack[layer + 1] = tempboard;
				Solve(layer + 1);
			}

		}
		tempboard = boardstack[layer];
		if (movebottom(tempboard)) {

			if (!seen(tempboard, layer))
			{
				boardstack[layer + 1] = tempboard;
				Solve(layer + 1);
			}

		}
		tempboard = boardstack[layer];
		if (moveLeft(tempboard)) {

			if (!seen(tempboard, layer))
			{
				boardstack[layer + 1] = tempboard;
				Solve(layer + 1);
			}

		}
		tempboard = boardstack[layer];
		if (movetop(tempboard)) {

			if (!seen(tempboard, layer))
			{
				boardstack[layer + 1] = tempboard;
				Solve(layer + 1);
			}

		}
		
		
	}
	int result() // is it supposed to be in solve or outisde
	{
		return bestSolution;
	}

	bool moveLeft(board& tempboard) {
		for (int row = 0; row < size; row++)  //scanning for marbles
		{
			for (int col = 1; col < size; col++)
			{
				if (tempboard.theBoard[row][col] > 0)
				{
					int tempcol = col;
					while (tempcol > 0) { //found a ball. move it left.
						//if there's a wall break out of the loop. a wall = 

						if (walls[row][tempcol].left == true)
						{
							break;
						}
						//if there's a ball break out of the loop
						if (tempboard.theBoard[row][tempcol - 1] > 0)
						{
							break;
						}
						// if there's a hole:
							//type 1: the right hole
								//tempcol becomes 0 (ball went in hole)
								//tempcol-1 becomes 0 (hole went away)
								//break out of the loop
						if (tempboard.theBoard[row][tempcol - 1] < 0)
						{
							if (tempboard.theBoard[row][tempcol] + tempboard.theBoard[row][tempcol - 1] == 0)
							{
								//pozzleboard[col, row].BallorHole
								tempboard.theBoard[row][tempcol] = 0;
								tempboard.theBoard[row][tempcol - 1] = 0;
								break;                                                                 // added this
							}
							else {
								return false;
							}
						}
						//type 2: the wrong hole
							//return false


					//time to move the ball over
					//tempcol -1 gets the ball value (ball slides over)
					//tempcol becomes 0 (no ball here now)

						tempboard.theBoard[row][tempcol - 1] = tempboard.theBoard[row][tempcol];
						tempboard.theBoard[row][tempcol] = 0;
						tempcol--;
					}

				}
			}
		}
		return true;
	}
	bool moveright(board& tempboard) {
		for (int row = 0; row < size-1; row++)  //scanning for marbles          added size -1
		{
			for (int col = size - 2; col >= 0; col--)
			{
				if (tempboard.theBoard[row][col] > 0) //finds marbles
				{
					int tempcol = col;
					while (tempcol < size - 1) { //found a ball. move it left.
						//if there's a wall break out of the loop. a wall = 
						if (walls[row][tempcol].right == true)
						{
							break;
						}
						//if there's a ball break out of the loop
						/*if (tempboard.theBoard[row][tempcol + 1] > 0)
						{
							break;
						}*/
						// if there's a hole:
							//type 1: the right hole
								//tempcol becomes 0 (ball went in hole)
								//tempcol-1 becomes 0 (hole went away)
								//break out of the loop
						if (tempboard.theBoard[row][tempcol + 1] < 0)
						{
							if (tempboard.theBoard[row][tempcol] + tempboard.theBoard[row][tempcol + 1] == 0)
							{
								tempboard.theBoard[row][tempcol] = 0;
								tempboard.theBoard[row][tempcol + 1] = 0;
								break;                                               //added this
							}
							else {
								return false;
							}
						}
						//type 2: the wrong hole
							//return false

						if (tempboard.theBoard[row][tempcol + 1] > 0)
						{
							break;
						}
					//time to move the ball over
					//tempcol -1 gets the ball value (ball slides over)
					//tempcol becomes 0 (no ball here now)

						tempboard.theBoard[row][tempcol + 1] = tempboard.theBoard[row][tempcol];
						tempboard.theBoard[row][tempcol] = 0;
						tempcol++;
					}

				}
			}
		}
		return true;
	}
	bool movebottom(board& tempboard) {
		for (int row = size - 2; row >= 0; row--)  //scanning for marbles
		{
			for (int col = 0; col < size; col++)
			{
				if (tempboard.theBoard[row][col] > 0)
				{
					int temprow = row;
					while (temprow < size-1) { //found a ball. move it left.
						//if there's a wall break out of the loop. a wall = 
						if (walls[temprow][col].bottom == true)
						{
							break;
						}
						//if there's a ball break out of the loop
						if (tempboard.theBoard[temprow+1][col] > 0)
						{
							break;
						}
						// if there's a hole:
							//type 1: the right hole
								//tempcol becomes 0 (ball went in hole)
								//tempcol-1 becomes 0 (hole went away)
								//break out of the loop
						if (tempboard.theBoard[temprow+1][col] < 0)
						{
							if (tempboard.theBoard[temprow][col] + tempboard.theBoard[temprow+1][col] == 0)
							{
								tempboard.theBoard[temprow][col] = 0;
								tempboard.theBoard[temprow+1][col] = 0;
								break;
							}
							else {
								return false;
							}
						}
						//type 2: the wrong hole
							//return false


					//time to move the ball over
					//tempcol -1 gets the ball value (ball slides over)
					//tempcol becomes 0 (no ball here now)

						tempboard.theBoard[temprow +1][col] = tempboard.theBoard[temprow][col];
						tempboard.theBoard[temprow][col] = 0;
						temprow++;
					}

				}
			}
		}
		return true;
	}

	bool movetop(board& tempboard) {
		for (int row = 1; row < size; row++)  //scanning for marbles
		{
			for (int col = 0; col < size; col++)
			{
				if (tempboard.theBoard[row][col] > 0)
				{
					int temprow = row;
					while (temprow > 0) { //found a ball. move it left.
						//if there's a wall break out of the loop. a wall = 
						if (walls[temprow][col].top == true)
						{
							break;
						}
						//if there's a ball break out of the loop
						if (tempboard.theBoard[temprow -1][col] > 0)
						{
							break;
						}
						// if there's a hole:
							//type 1: the right hole
								//tempcol becomes 0 (ball went in hole)
								//tempcol-1 becomes 0 (hole went away)
								//break out of the loop
						if (tempboard.theBoard[temprow -1][col] < 0)
						{
							if (tempboard.theBoard[temprow][col] + tempboard.theBoard[temprow-1][col] == 0)
							{
								tempboard.theBoard[temprow][col] = 0;
								tempboard.theBoard[temprow-1][col] = 0;
								break;
							}
							else {
								return false;
							}
						}
						//type 2: the wrong hole
							//return false


					//time to move the ball over
					//tempcol -1 gets the ball value (ball slides over)
					//tempcol becomes 0 (no ball here now)

						tempboard.theBoard[temprow -1][col] = tempboard.theBoard[temprow][col];
						tempboard.theBoard[temprow][col] = 0;
						temprow--;
					}

				}
			}
		}
		return true;
	}

};



int main()
{
	MarbleBoard theBoard;

	ifstream infile;
	infile.open("1move.txt", ios::in);
	int size, ballCount, wallCount;
	infile >> size >> ballCount >> wallCount;


	theBoard.setSize(size, ballCount, wallCount);

	int row, col;
	for (int i = 0; i < ballCount; i++) //adds balls
	{
		infile >> row >> col;
		theBoard.addBall(row, col, i + 1);
	}
	for (int i = 0; i < ballCount; i++) //adds holes
	{
		infile >> row >> col;
		theBoard.addBall(row, col, (i + 1) * -1);
	}
	//add wall loop
	int row2, col2;
	for (int i = 0; i < wallCount; i++) // how would you write add wall loop
	{
		infile >> row >> col >> row2 >> col2;
		theBoard.addwall(row, col, row2, col2);
	}



	theBoard.Solve(0);
	cout << "Best Solution: ";
	cout << theBoard.result();
	infile.close();




	return 0;
}