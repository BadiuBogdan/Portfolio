/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.util.List;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author badiu
 */
public class InfoCardDaoImpl implements InfoCardDao {
    private Connection getConnection() throws SQLException, ClassNotFoundException {
        Class.forName("org.apache.derby.jdbc.EmbeddedDriver");
        String dbUrl = "jdbc:derby://localhost:1527/ManagerCard";
        Properties props = new Properties();
        props.put("user", "Banca");
        props.put("password", "banca1234");
        Connection connection = DriverManager.getConnection(dbUrl, props);
        return connection;
    }

    @Override
    public List<InfoCard> getAllInfoCard() {
       return null;
    }

    @Override
    public InfoCard getInfoCard(String codCard) {
        Connection conn = null;
        InfoCard card;
        double sold = 0;
        int id = 0;
        String pin = "";
        String cod = "";
        try {
            conn=getConnection();
            String sqlSelect="select * from INFO_CARD WHERE COD_CARD= ?";
            PreparedStatement stmt = conn.prepareStatement(sqlSelect);
            stmt.setString(1, codCard);
            ResultSet results = stmt.executeQuery();
            ResultSetMetaData rsmd = results.getMetaData();
            if (results.next()) {
                id = results.getInt(rsmd.getColumnName(1));
                cod = results.getString(rsmd.getColumnName(2));
                pin = results.getString(rsmd.getColumnName(3));
                sold = results.getDouble(rsmd.getColumnName(4));
            }
        } catch (SQLException ex) {
            Logger.getLogger(InfoCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(InfoCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }

        card = new InfoCard(id,cod, pin, sold);
        try {
            conn.close();
        } catch (SQLException ex) {
            Logger.getLogger(InfoCardDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return card;
    }

    @Override
    public void updateInfoCard(InfoCard infoCard) {
       
    }

    @Override
    public void deleteDetinatorCard(InfoCard infoCard) {
     
    }

    @Override
    public void insertDetinatorCard(InfoCard infoCard) {
       
    }
    
}
