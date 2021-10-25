/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

import javafx.geometry.Insets;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;

/**
 *
 * @author badiu
 */
public class VerificareCard100 {

    private TextField nrCard;
    private PasswordField pin;
    private Label pinLabel;
    private Button finalizareVanzare;
    private Button returnBtn;

    public PasswordField getPin() {
        return pin;
    }

    public void setPin(PasswordField pin) {
        this.pin = pin;
    }

    public Label getPinLabel() {
        return pinLabel;
    }

    public void setPinLabel(Label pinLabel) {
        this.pinLabel = pinLabel;
    }

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

    public VerificareCard100(GridPane grid) {
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

        //Pin Label
        pinLabel = new Label("Intoduceti pin: ");
        GridPane.setConstraints(pinLabel, 0, 1);

        //Pin Input
        pin = new PasswordField();
        pin.setPromptText("Enter Your Pin Card");
        GridPane.setConstraints(pin, 1, 1);

        //Button Vanzare
        finalizareVanzare = new Button("Vanzare");
        GridPane.setConstraints(finalizareVanzare, 0, 2);

        //Button Return
        returnBtn = new Button("Return");
        GridPane.setConstraints(returnBtn, 1, 2);

        //Config the GridPane
        grid.getChildren().addAll(userLabel, nrCard, pinLabel, pin, finalizareVanzare, returnBtn);
    }
}
