package sudoku;

import org.apache.commons.lang3.SystemUtils;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class FileSudokuBoardDaoTest {

    /*------------------------ FIELDS REGION ------------------------*/
    private SudokuBoardDaoFactory factory = new SudokuBoardDaoFactory();
    private SudokuBoard sudokuBoard = new SudokuBoard();

    private Dao<SudokuBoard> fileSudokuBoardDao;
    private SudokuBoard sudokuBoardSecond;

    /*------------------------ METHODS REGION ------------------------*/
    @Test
    public void writeReadTest() {
        fileSudokuBoardDao = factory.getFileDao("xxx.txt");
        fileSudokuBoardDao.write(sudokuBoard);
        sudokuBoardSecond = fileSudokuBoardDao.read();

        assertEquals(sudokuBoard, sudokuBoardSecond);
    }

    @Test(expected = FileOperationException.class)
    public void readIOExceptionTest() {
        fileSudokuBoardDao = factory.getFileDao("yyy.txt");
        fileSudokuBoardDao.read();
    }

    @Test(expected = FileOperationException.class)
    public void writeIOExceptionTest() {
        if (SystemUtils.IS_OS_WINDOWS) {
            fileSudokuBoardDao = factory.getFileDao("?");
        } else if (SystemUtils.IS_OS_LINUX) {
            fileSudokuBoardDao = factory.getFileDao("/");
        } else {
            fileSudokuBoardDao = factory.getFileDao("?");
        }
        fileSudokuBoardDao.write(sudokuBoard);
    }

}
