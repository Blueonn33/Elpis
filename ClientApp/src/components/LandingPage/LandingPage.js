import React, { Component } from 'react';
import '../LandingPage/LandingPageStyles.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.js';
import 'bootstrap/dist/css/bootstrap.css';

export class LandingPage extends Component {
    static displayName = LandingPage.name;

    render() {
        return (
            <div>
                <div className="landingPageContainer">
                    <div className="backgroundImgContainer">
                        <img className="landingPageImg responsive" src='/Images/LandingPageBackGround.jpg' alt="Restaurant" href='/Images/LandingPageBackGround.jpg' />
                    </div>
                    <div className="landingPageName">
                        ЕЛПИС
                    </div>
                    {/*<div className="introContainer">*/}
                    {/*    <p>*/}
                    {/*        Добре дошли в ресторант Елпис – място, където всяко ястие е истинско кулинарно изживяване*/}
                    {/*        и всяка среща е запомнящ се момент. Създадохме тази обстановка с мисъл за вашето удоволствие*/}
                    {/*        и комфорт, като съчетахме изискан дизайн с уютна атмосфера, за да ви предложим*/}
                    {/*        перфектното място за вечеря с приятели, семейни събирания или специални поводи.*/}
                    {/*    </p>*/}
                    {/*    <p>*/}
                    {/*        Менюто на Елпис е вдъхновено от най-добрите кулинарни традиции, съчетани с модерни техники и свежи,*/}
                    {/*        висококачествени продукти. Всеки детайл е внимателно подбран, за да ви предложим не просто храна,*/}
                    {/*        а истинско удоволствие. Нашите талантливи готвачи работят с страст и прецизност, за да създадат ястия,*/}
                    {/*        които радват всички сетива.*/}
                    {/*    </p>*/}
                    {/*    <p>*/}
                    {/*        Освен невероятната храна, в Елпис ви предлагаме и богата винена листа, подбрана с грижа и внимание,*/}
                    {/*        за да допълни перфектно вашето кулинарно изживяване. Нашият професионален и любезен персонал е*/}
                    {/*        винаги на ваше разположение, за да направи вашето посещение при нас незабравимо.*/}
                    {/*    </p>*/}
                    {/*    <p>*/}
                    {/*        Заповядайте в ресторант Елпис и се насладете на уют, изисканост и незабравими вкусове!*/}
                    {/*    </p>*/}
                    {/*</div>*/}
                </div>
            </div>
        );
    }
}
