package selling.system;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;
import java.util.logging.Level;

/**
 *
 * @author Gabi
 */
public class UsersDaoImpl implements UsersDao {


    
    private Connection getConnection() throws ClassNotFoundException, SQLException {
        Class.forName("org.apache.derby.jdbc.EmbeddedDriver");
        String dbUrl = "jdbc:derby://localhost:1527/Magazin";
        Properties props = new Properties();
        props.put("user", "Magazin");
        props.put("password", "magazin1234");
        Connection connection = DriverManager.getConnection(dbUrl, props);
        return connection;
    }

    @Override
    public List<Users> getAllUsers() {
        Connection conn = null;
        List <Users> lista = new ArrayList<>();
        try {
            conn = getConnection();
            Statement stmt = conn.createStatement();
            ResultSet results = stmt.executeQuery("SELECT * FROM USERS");
            while(results.next()){
                int idUser = results.getInt(1);
                String username = results.getString(2);
                String password = results.getString(3);
                String functie = results.getString(4);
                lista.add(new Users(idUser,username,password,functie));
            }
                      
        } catch (ClassNotFoundException ex) { 
            java.util.logging.Logger.getLogger(UsersDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            java.util.logging.Logger.getLogger(UsersDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            conn.close();
        } catch (SQLException ex) {
            java.util.logging.Logger.getLogger(UsersDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return lista;
    }

    @Override
    public Users getUser(String username) {
        Connection conn = null;
        int idUser = 0;
        String user = "";
        String password = "";
        String functie = "";
        Users users;
        try{
        conn = getConnection();
        String querySearch = "SELECT * from USERS where USERNAME=?";
        PreparedStatement stmt = conn.prepareStatement(querySearch);
        stmt.setString(1,username);
        ResultSet rst = stmt.executeQuery();
        ResultSetMetaData rsmd = rst.getMetaData();
        if(rst.next()){
            idUser = rst.getInt(rsmd.getColumnName(1));
            user = rst.getString(rsmd.getColumnName(2));
            password = rst.getString(rsmd.getColumnName(3));
            functie = rst.getString(rsmd.getColumnName(4));
        }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(UsersDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            java.util.logging.Logger.getLogger(UsersDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        users = new Users(idUser, username, password, functie);
        try {
            conn.close();
        } catch (SQLException ex) {
            java.util.logging.Logger.getLogger(UsersDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return users;
    }

    @Override
    public void updateUser(Users user) {

    }

    @Override
    public void deleteUser(Users user) {

    }

    @Override
    public void insertUser(Users user) {

    }

}
