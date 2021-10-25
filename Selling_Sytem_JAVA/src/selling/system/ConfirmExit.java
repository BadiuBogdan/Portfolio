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
import javafx.scene.layout.HBox;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.stage.Modality;
import javafx.stage.Stage;

/**
 *
 * @author badiu
 */
public class ConfirmExit {
    private boolean answer=true;

    public boolean conf(String text) {
         

        //Configurare Stage
        Stage window = new Stage();
        window.initModality(Modality.APPLICATION_MODAL);
        window.setTitle("Important!!");
        window.setMaxWidth(1000);
        window.setMaxHeight(300);

        //Label pentru anuntare
        Label label = new Label(text);
        label.setFont(new Font("Arial", 36));
        label.setTextFill(Color.BLACK);

        //Button Yes
        Button btnYes = new Button("Yes");
        btnYes.setOnAction((ActionEvent event) -> {
            answer=true;
            window.close();
        });
        
        //Button No
        Button btnNo = new Button("No");
        btnNo.setOnAction((ActionEvent event) ->{ 
                    answer=false;
                window.close(); 
          });

        //Config Layout
        HBox layout = new HBox(10);
        layout.getChildren().addAll(label, btnYes,btnNo);
        layout.setAlignment(Pos.CENTER);

        //Config Scene
        Scene scene = new Scene(layout, 900,200);
        
        //Incarcare imagine
         Image icon =new Image("/resurse/warning.png");

        //Set the window
        window.setScene(scene);
        window.getIcons().add(icon);//Pune iconita
        window.showAndWait();
     return answer;   
    }

    
}
