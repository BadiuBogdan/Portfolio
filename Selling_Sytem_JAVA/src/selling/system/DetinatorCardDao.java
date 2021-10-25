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
public interface DetinatorCardDao {

    public List<DetinatorCard> getAllDetinatorCard();

    public DetinatorCard getDetinatorCard(String cnp);

    public void updateDetinatorCard(DetinatorCard detinator);

    public void deleteDetinatorCard(DetinatorCard detinator);

    public void insertDetinatorCard(DetinatorCard detinator);
}
