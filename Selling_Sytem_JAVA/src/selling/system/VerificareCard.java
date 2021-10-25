/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

import javafx.geometry.Insets;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;

/**
 *
 * @author badiu
 */
public class VerificareCard {

    private TextField nrCard;
    private Button finalizareVanzare;
    private Button returnBtn;
    

    public TextField getNrCard() {
        return nrCard;
    }

    public void setNrCard(TextField nrCard) {
        this.nrCard = nrCard;
    }

    public Button getFinalizareVanzare() {
        return finalizareVanzare;
    }

    public void setFinalizareVanzare(Button finalizareVanzare) {
        this.finalizareVanzare = finalizareVanzare;
    }

    public Button getReturnBtn() {
        return returnBtn;
    }

    public void setReturnBtn(Button returnBtn) {
        this.returnBtn = returnBtn;
    }

    public VerificareCard(GridPane grid) {
        //Grid Pane properties
        grid.setPadding(new Insets(20, 20, 20, 20));
        grid.setVgap(10);
        grid.setHgap(12);

        //Name Label
        Label userLabel = new Label("Numarul Cardului: ");
        GridPane.setConstraints(userLabel, 0, 0);

        //NR Card Input
        nrCard = new TextField();
        nrCard.setPromptText("Enter Your Card Number");
        GridPane.setConstraints(nrCard, 1, 0);
        

        //Button Vanzare
        finalizareVanzare = new Button("Vanzare");
        GridPane.setConstraints(finalizareVanzare, 0, 2);

        //Button Return
        returnBtn = new Button("Return");
        GridPane.setConstraints(returnBtn, 1, 2);

        //Config the GridPane
        grid.getChildren().addAll(userLabel, nrCard, finalizareVanzare, returnBtn);
    }
}
