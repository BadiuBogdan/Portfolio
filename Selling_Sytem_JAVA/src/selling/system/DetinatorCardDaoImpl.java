/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.List;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author badiu
 */
public class DetinatorCardDaoImpl implements DetinatorCardDao{
     private Connection getConnection() throws SQLException, ClassNotFoundException {
        Class.forName("org.apache.derby.jdbc.EmbeddedDriver");
        String dbUrl = "jdbc:derby://localhost:1527/ManagerCard";
        Properties props = new Properties();
        props.put("user", "Banca");
        props.put("password", "banca1234");
        Connection connection = DriverManager.getConnection(dbUrl, props);
        return connection;
    }

    private void Conectare(Connection conn) {
        
        try {
            conn = getConnection();
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(DetinatorCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
     @Override
    public List<DetinatorCard> getAllDetinatorCard() {
        Connection conn=null;
        Conectare(conn);

        try {
            conn.close();
        } catch (SQLException ex) {
            Logger.getLogger(DetinatorCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }

    @Override
    public DetinatorCard getDetinatorCard(String cnp) {
        Connection conn=null;
        Conectare(conn);
        try {
            conn.close();
        } catch (SQLException ex) {
            Logger.getLogger(DetinatorCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;

    }

    @Override
    public void updateDetinatorCard(DetinatorCard detinator) {
        Connection conn=null;
        Conectare(conn);
        try {
            conn.close();
        } catch (SQLException ex) {
            Logger.getLogger(DetinatorCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void deleteDetinatorCard(DetinatorCard detinator) {
        Connection conn=null;
        Conectare(conn);
        try {
            conn.close();
        } catch (SQLException ex) {
            Logger.getLogger(DetinatorCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void insertDetinatorCard(DetinatorCard detinator) {
        Connection conn=null;
        Conectare(conn);
        try {
            conn.close();
        } catch (SQLException ex) {
            Logger.getLogger(DetinatorCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
