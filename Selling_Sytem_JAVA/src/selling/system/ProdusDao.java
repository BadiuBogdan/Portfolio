package selling.system;

import java.util.List;

/**
 *
 * @author Gabi
 */
public interface ProdusDao {

    public List<Produs> getAllProdus();

    public Produs getProdus(String codBare);

    public void updateProdus(String numeProdus);

    public void deteleProdus(String numeProdus);

    public void insertProdus(Produs produs);
}
