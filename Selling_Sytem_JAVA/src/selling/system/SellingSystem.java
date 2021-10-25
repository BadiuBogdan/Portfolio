/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;

/**
 *
 * @author badiu
 */
public class SellingSystem extends Application {

    private static SellingSystem system;

    private Stage window;
    private Scene scena_logare;
    private Scene scena_angajat;
    private Scene scena_verifica;
    private Logare logare;
    private VerificareCard100 verifica;
    private VerificareCard verifica2;
    private About about;
    private InfoCardDaoImpl mCard;
    private InfoCard info;
    private UsersDaoImpl uDao;
    private Users user;
    private ProdusDao pDao;
    private Produs produs;
    private boolean gasireProd;
    private ConfirmExit exit;

    public boolean isGasireProd() {
        return gasireProd;
    }

    public void setGasireProd(boolean gasireProd) {
        this.gasireProd = gasireProd;
    }

    //Pana rezolvam asta private Client client;
    @Override
    public void start(Stage primaryStage) throws IOException {
        info = new InfoCard();
        mCard = new InfoCardDaoImpl();
        uDao = new UsersDaoImpl();
        pDao = new ProdusDaoImpl();
        system = this;
        //client = new Client("127.0.0.1", 4444);

        window = primaryStage;
        //----------------Initializare logare---------------------------------------
        GridPane grid_logare = new GridPane();//Declararea gridului pentru logare
        scena_logare = new Scene(grid_logare, 400, 200);
        logare = new Logare(grid_logare);//initializarea obiectului care afiseaza logarea

        //*************Evenimentele de la Logare***************
        logare.getLoginBtn().setOnAction((new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                user = uDao.getUser(logare.getUserText().getText());
                if (logare.getPassText().getText().equals(user.getPassword())
                        && logare.getUserText().getText().equals(user.getUsername())
                        && user.getFunctie().equals("manager")) {
                    try {
                        //Incarcare fisier Manager.fxml pentru incarcare
                        Parent root = FXMLLoader.load(getClass().getResource("Manager.fxml"));

                        //Configurare Scene Manager
                        scena_angajat = new Scene(root, 960, 600);

                        //Configurare Window Manager
                        window.setScene(scena_angajat);
                    } catch (IOException ex) {
                        Logger.getLogger(SellingSystem.class.getName()).log(Level.SEVERE, null, ex);
                    }
                } else if (logare.getPassText().getText().equals(user.getPassword())
                        && logare.getUserText().getText().equals(user.getUsername())
                        && user.getFunctie().equals("casier")) {
                    try {
                        //Incarcare fisier Casier.fxml pentru incarcare
                        Parent root = FXMLLoader.load(getClass().getResource("Casier.fxml"));

                        //Configurare Scene Casier
                        scena_angajat = new Scene(root, 960, 600);

                        //Configurare Window casier
                        window.setScene(scena_angajat);
                    } catch (IOException ex) {
                        Logger.getLogger(SellingSystem.class.getName()).log(Level.SEVERE, null, ex);
                    }
                } else {
                    about = new About("User-ul nu a fost gasit", "Va rugam sa "
                            + "mai incercati ", 1);
                }
            }
        }));

        //*************Sfarsit Evenimentele de la Logare***************
        //----------------Sfarsit Initializare logare---------------------------------------
        //Interogare inchidere scena de la buton stage
        window.setOnCloseRequest((WindowEvent event) -> {
            event.consume();
            exit=new ConfirmExit();
        boolean answer = exit.conf("Sigur doriti sa inchdeti aplicatia?");
        if (answer) {
             window.close();
        }
        });
        //Configurare Stage
        window.setTitle("Selling System");
        window.setScene(scena_logare);
        window.resizableProperty().setValue(Boolean.FALSE);//Scoate buton de maximizare
        window.show();
    }

    /**
     * @param args the command line arguments
     * @throws java.io.IOException
     */
    public static void main(String[] args) throws IOException {
        launch(args);
    }

    public static SellingSystem getSystem() {
        return system;
    }

    public Stage getWindow() {
        return window;
    }

    public void setWindow(Stage window) {
        this.window = window;
    }

    public Scene getScena_logare() {
        return scena_logare;
    }

    public void setScena_logare(Scene scena_logare) {
        this.scena_logare = scena_logare;
    }

    public Logare getLogare() {
        return logare;
    }

    public void clearLogare() {
        logare.getUserText().setText("");
        logare.getPassText().setText("");
    }

    public String getUsernameLogare() {
        return logare.getUserText().getText();
    }

    public String calculeazaPret(String cantitate, double pretUnitar) {
        double cant = Double.parseDouble(cantitate);
        double sum = cant * pretUnitar;
        String sum2 = Double.toString(sum);
        return sum2;
    }

    public Produs cautaProdus(String cod) {
        produs = pDao.getProdus(cod);
        if (produs.getIdProdus() == 0) {
            about = new About("Produsul nu exista sau a fost scos", "Va rugam"
                    + " sa verificati codul sau  intrebati superiorul ", 1);
            gasireProd = false;
        } else {
            gasireProd = true;
        }
        return produs;
    }

    public void scenaVerificaCard(String a) {

        //----------------Initializare verifica---------------------------------------
        GridPane grid_verifica = new GridPane();
        double b = Double.parseDouble(a);
        if (b > 100) {
            verifica = new VerificareCard100(grid_verifica);

        } else {
            verifica2 = new VerificareCard(grid_verifica);

        }

        scena_verifica = new Scene(grid_verifica, 500, 200);
        //*************Evenimentele de la Verifica***************
        if (b > 100) {
            verifica.getReturnBtn().setOnAction((ActionEvent event) -> {
                window.setScene(scena_angajat);
            });
            verifica.getFinalizareVanzare().setOnAction((ActionEvent event) -> {

                info = mCard.getInfoCard(verifica.getNrCard().getText());
                if (b <= info.getSold() && verifica.getNrCard().getText().equals(info.getCodCard()) && verifica.getPin().getText().equals(info.getPin())) {

                    about = new About("Cardul a fost validat", "Tranzactie "
                            + "in curs ", 2);

                } else {
                    about = new About("Cardul nu este validat", "Va rugam"
                            + " sa mai incercati sau contactati banca ", 1);
                }
            });
        } else {
            verifica2.getReturnBtn().setOnAction((ActionEvent event) -> {
                window.setScene(scena_angajat);
            });
            verifica2.getFinalizareVanzare().setOnAction((ActionEvent event) -> {
                info = mCard.getInfoCard(verifica2.getNrCard().getText());
                if (b <= info.getSold() && verifica2.getNrCard().getText().equals(info.getCodCard())) {

                    about = new About("Cardul a fost validat", "Tranzactie "
                            + "in curs ", 2);

                } else {
                    about = new About("Cardul nu este validat", "Va rugam sa "
                            + "mai incercati sau contactati banca ", 1);
                }
            });
        }
        //*************Sfarsit Evenimentele de la LVerifica***************
        //----------------Sfarsit Initializare Verifica---------------------------------------
        window.setScene(scena_verifica);
    }
     public void logOut() {
         exit=new ConfirmExit();
        boolean answer = exit.conf("Sigur doriti sa parasiti sesiunea?");
        if (answer) {
             window.setScene(scena_logare);
        }
    }

}
