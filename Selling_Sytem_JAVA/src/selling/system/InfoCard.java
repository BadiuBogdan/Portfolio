/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

/**
 *
 * @author badiu
 */
public class InfoCard {

    private int idCard;
    private String codCard;
    private String pin;
    private double sold;

    public InfoCard() {

    }

    public InfoCard(int idCard, String codCard, String pin, double sold) {
        this.idCard = idCard;
        this.codCard = codCard;
        this.pin = pin;
        this.sold = sold;
    }

    public int getIdCard() {
        return idCard;
    }

    public void setIdCard(int idCard) {
        this.idCard = idCard;
    }

    public String getCodCard() {
        return codCard;
    }

    public void setCodCard(String codCard) {
        this.codCard = codCard;
    }

    public double getSold() {
        return sold;
    }

    public void setSold(double sold) {
        this.sold = sold;
    }

    public String getPin() {
        return pin;
    }

    public void setPin(String pin) {
        this.pin = pin;
    }

}
