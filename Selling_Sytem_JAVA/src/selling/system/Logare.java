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
public class Logare {

    private TextField userText;
    private PasswordField passText;
    private Button loginBtn;


    public TextField getUserText() {
        return userText;
    }

    public void setUserText(TextField userText) {
        this.userText = userText;
    }

    public PasswordField getPassText() {
        return passText;
    }

    public void setPassText(PasswordField passText) {
        this.passText = passText;
    }

    public Button getLoginBtn() {
        return loginBtn;
    }

    public void setLoginBtn(Button loginBtn) {
        this.loginBtn = loginBtn;
    }

    public Logare(GridPane grid) {
        //Grid Pane properties
        grid.setPadding(new Insets(20, 20, 20, 20));
        grid.setVgap(10);
        grid.setHgap(12);

        //Name Label
        Label userLabel = new Label("Username: ");
        GridPane.setConstraints(userLabel, 0, 0);

        //Name Input
        userText = new TextField();
        userText.setPromptText("Enter Your Name");
        GridPane.setConstraints(userText, 1, 0);

        //Password Label
        Label passLabel = new Label("Password: ");
        GridPane.setConstraints(passLabel, 0, 1);

        //Password Input
        passText = new PasswordField();
        passText.setPromptText("Enter Your Password");
        GridPane.setConstraints(passText, 1, 1);

        //Button Login
        loginBtn = new Button("LogIn");
        GridPane.setConstraints(loginBtn, 1, 2);

        //Config the GridPane
        grid.getChildren().addAll(userLabel, userText, passLabel, passText, loginBtn);
        
    }
}
