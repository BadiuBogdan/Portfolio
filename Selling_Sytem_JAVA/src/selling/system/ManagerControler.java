/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

import java.net.URL;
import java.time.LocalDate;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;


/**
 * FXML Controller class
 *
 * @author badiu
 */
public class ManagerControler implements Initializable {
 private Produs prod;
    private double total;

    @FXML
    private Label data;
    @FXML
    private Label angajat;

    @FXML
    private Label pret;

    @FXML
    private TextField codBare;

    @FXML
    private TableView<SalesLineItem> tabel;
    @FXML
    private TableColumn<SalesLineItem, String> col_denumire;
    @FXML
    private TableColumn<SalesLineItem, String> col_descriere;
    @FXML
    private TableColumn<SalesLineItem, String> col_pretUnitar;
    @FXML
    private TableColumn<SalesLineItem, String> col_cantitate;
    @FXML
    private TableColumn<SalesLineItem, String> col_pret;
    @FXML
    private Button verifica;
    @FXML
    private TextField cant;

    /**
     * Initializes the controller class.
     *
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        tabel.getItems().clear();
        total=0;
        col_denumire.setStyle("-fx-alignment: CENTER;");
         col_descriere.setStyle("-fx-alignment: CENTER;");
         col_pretUnitar.setStyle("-fx-alignment: CENTER;");
         col_cantitate.setStyle("-fx-alignment: CENTER;");
         col_pret.setStyle("-fx-alignment: CENTER;");
         
        LocalDate ldata = LocalDate.now();
        data.setText(ldata.toString());
        angajat.setText(SellingSystem.getSystem().getUsernameLogare().toUpperCase());
    }

    @FXML
    private void logOut(ActionEvent event) {
        SellingSystem.getSystem().clearLogare();
        SellingSystem.getSystem().logOut();
    }

    @FXML
    private void verificaAc(ActionEvent event) {

        SellingSystem.getSystem().scenaVerificaCard(pret.getText());

    }
    @FXML
    private void newSale(ActionEvent event) {
        tabel.getItems().clear();
        total=0;
        pret.setText("0");

    }

    @FXML
    private void scanare(ActionEvent event) {
        prod = SellingSystem.getSystem().cautaProdus(codBare.getText());

        String pretStr1 = Double.toString(prod.getPretFinal());
        String pretFinal = SellingSystem.getSystem().calculeazaPret(cant.getText(), prod.getPretFinal());
        double pretF=Double.parseDouble(pretFinal);
        total=total+pretF;
        String totalString=Double.toString(total);
        
       
        col_denumire.setCellValueFactory(new PropertyValueFactory<>("denumire"));
        col_descriere.setCellValueFactory(new PropertyValueFactory<>("descriere"));
        col_pretUnitar.setCellValueFactory(new PropertyValueFactory<>("pretUnitar"));
        col_cantitate.setCellValueFactory(new PropertyValueFactory<>("cantitate"));
        col_pret.setCellValueFactory(new PropertyValueFactory<>("pret"));
        if (SellingSystem.getSystem().isGasireProd() == true) {
            tabel.getItems().add(new SalesLineItem(prod.getNumeProdus(), prod.getDescriere(), pretStr1, cant.getText(), pretFinal));
        }
        pret.setText(totalString);
    }
}
