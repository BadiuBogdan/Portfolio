/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package selling.system;

import java.util.List;

/**
 *
 * @author badiu
 */
public interface InfoCardDao {

    public List<InfoCard> getAllInfoCard();

    public InfoCard getInfoCard(String codCard);

    public void updateInfoCard(InfoCard infoCard);

    public void deleteDetinatorCard(InfoCard infoCard);

    public void insertDetinatorCard(InfoCard infoCard);
}
