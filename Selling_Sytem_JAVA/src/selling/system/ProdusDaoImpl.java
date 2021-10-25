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
import java.util.logging.Logger;

/**
 *
 * @author Gabi
 */
public class ProdusDaoImpl implements ProdusDao {

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
    public List<Produs> getAllProdus() {
        Connection conn = null;
        int idProdus = 0;
        String numeProdus = "";
        String codBare = "";
        String descriereProdus = "";
        double adaosComercial = 0;
        double pretFinal = 0;
        int idTip = 0;
        List<Produs> lista = new ArrayList<>();
        try {
            conn = getConnection();
            Statement stmt = conn.createStatement();
            ResultSet rst = stmt.executeQuery("SELECT * FROM PRODUS");
            lista.clear();
            while (rst.next()) {
                idProdus = rst.getInt(1);
                numeProdus = rst.getString(2);
                codBare = rst.getString(3);
                descriereProdus = rst.getString(4);
                adaosComercial = rst.getDouble(5);
                pretFinal = rst.getDouble(6);
                idTip = rst.getInt(7);
                lista.add(new Produs(idProdus, numeProdus, codBare, descriereProdus, adaosComercial, pretFinal, idTip));
            }
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(ProdusDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(ProdusDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            conn.close();
        } catch (SQLException ex) {
            Logger.getLogger(ProdusDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return lista;
    }

    @Override
    public Produs getProdus(String codBare) {
        Connection conn = null;
        int idProdus = 0;
        String numeProdus = "";
        String cod = "";
        String descriereProdus = "";
        double adaosComercial = 0;
        double pretFinal = 0;
        int idTip = 0;
        Produs produs;
        try {
            conn = getConnection();
            String querySearch = "SELECT * from PRODUS where COD=?";
            PreparedStatement stmt = conn.prepareStatement(querySearch);
            stmt.setString(1, codBare);
            ResultSet rst = stmt.executeQuery();
            ResultSetMetaData rsmd = rst.getMetaData();
            if (rst.next()) {
                idProdus =rst.getInt(rsmd.getColumnName(1));
                numeProdus = rst.getString(rsmd.getColumnName(2));
                cod = rst.getString(rsmd.getColumnName(3));
                descriereProdus = rst.getString(rsmd.getColumnName(4));
                adaosComercial = rst.getDouble(rsmd.getColumnName(5));
                pretFinal = rst.getDouble(rsmd.getColumnName(6));
                idTip = rst.getInt(rsmd.getColumnName(7));
            }
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(ProdusDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(ProdusDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        produs = new Produs(idProdus, numeProdus, codBare, descriereProdus, adaosComercial, pretFinal, idTip);
        try {
            conn.close();
        } catch (SQLException ex) {
            Logger.getLogger(ProdusDaoImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return produs;
    }

    @Override
    public void updateProdus(String numeProdus) {

    }

    @Override
    public void deteleProdus(String numeProdus) {

    }

    @Override
    public void insertProdus(Produs produs) {

    }

}
