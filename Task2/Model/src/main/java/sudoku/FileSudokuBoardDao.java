package sudoku;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class FileSudokuBoardDao implements Dao<SudokuBoard> {

    /*------------------------ FIELDS REGION ------------------------*/
    private String filename;

    /*------------------------ METHODS REGION ------------------------*/
    public FileSudokuBoardDao(String filename) {
        this.filename = filename;
    }

    @Override
    public SudokuBoard read() {
        SudokuBoard obj = null;

        try (FileInputStream fileInputStream = new FileInputStream(filename);
             ObjectInputStream objectInputStream = new ObjectInputStream(fileInputStream)) {
            obj = (SudokuBoard) objectInputStream.readObject();
        } catch (ClassNotFoundException e) {
            throw new FileOperationException(e);
        } catch (IOException e) {
            throw new FileOperationException(e);
        }

        return obj;
    }

    @Override
    public void write(SudokuBoard obj) {
        try (FileOutputStream fileOutputStream = new FileOutputStream(filename);
             ObjectOutputStream objectOutputStream = new ObjectOutputStream(fileOutputStream)) {
            objectOutputStream.writeObject(obj);
        } catch (IOException e) {
            throw new FileOperationException(e);
        }
    }

}
