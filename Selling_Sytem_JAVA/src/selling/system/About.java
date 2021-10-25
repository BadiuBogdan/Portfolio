/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

import javafx.event.ActionEvent;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.stage.Modality;
import javafx.stage.Stage;

/**
 *
 * @author badiu
 */
public class About {
    private Image icon;
    public About(String mesaj1, String mesaj2,int color) {
        //Configurare Stage
        Stage window = new Stage();
        window.initModality(Modality.APPLICATION_MODAL);
        if(color==1){
        window.setTitle("Error");
        }else{window.setTitle("Confirmat");}
        window.setMaxWidth(800);
        window.setMaxHeight(300);

        //Label pentru cordonator
        Label label3 = new Label(mesaj1);
        label3.setFont(new Font("Arial", 32));
        if(color==1){
        label3.setTextFill(Color.RED);
        }else {label3.setTextFill(Color.GREEN);}   
        //Label pentru Autori
        Label label = new Label(mesaj2);
        label.setFont(new Font("Arial", 26));
        label.setTextFill(Color.BLACK);

        //Button from Modal
        Button closeButton = new Button("Ok");
        closeButton.setOnAction((ActionEvent event) -> window.close());

        //Configurare Layout pentru scena
        VBox layout = new VBox(10);
        layout.getChildren().addAll(label3, label, closeButton);
        layout.setAlignment(Pos.CENTER);

        //Configurare Scena
        Scene scene = new Scene(layout, 900, 200);

        //Incarcare imagine
        if(color==1){
             icon = new Image("/resurse/error.png");
        }else{ icon = new Image("/resurse/confirm.png");}
        //Setare stage
        window.setScene(scene);
        window.getIcons().add(icon);//Pune iconita
        window.showAndWait();
    }

}
