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
public class DetinatorCard {

    private int idCard;
    private String cnp;
    private String numeDetinator;
    private String prenume;

    public DetinatorCard(int idCard, String cnp, String numeDetinator, String prenume) {
        this.idCard = idCard;
        this.cnp = cnp;
        this.numeDetinator = numeDetinator;
        this.prenume = prenume;
    }

    public int getIdCard() {
        return idCard;
    }

    public void setIdCard(int idCard) {
        this.idCard = idCard;
    }

    public String getCnp() {
        return cnp;
    }

    public void setCnp(String cnp) {
        this.cnp = cnp;
    }

    public String getNumeDetinator() {
        return numeDetinator;
    }

    public void setNumeDetinator(String numeDetinator) {
        this.numeDetinator = numeDetinator;
    }

    public String getPrenume() {
        return prenume;
    }

    public void setPrenume(String prenume) {
        this.prenume = prenume;
    }
}
