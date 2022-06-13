package sudoku;

public class SudokuBoardDaoFactory {

    /*------------------------ METHODS REGION ------------------------*/
    public Dao<SudokuBoard> getFileDao(String filename) {
        return new FileSudokuBoardDao(filename);
    }
}
