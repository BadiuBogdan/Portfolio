package selling.system;

import java.util.logging.Logger;

public class TipProdus {

    private int idTip;
    private String numeTip;
    private float tva;

    public TipProdus(int idTip, String numeTip, float tva) {
        this.idTip = idTip;
        this.numeTip = numeTip;
        this.tva = tva;
    }

    public int getIdTip() {
        return idTip;
    }

    public void setIdTip(int idTip) {
        this.idTip = idTip;
    }

    public String getNumeTip() {
        return numeTip;
    }

    public void setNumeTip(String numeTip) {
        this.numeTip = numeTip;
    }

    public float getTva() {
        return tva;
    }

    public void setTva(float tva) {
        this.tva = tva;
    }

}
