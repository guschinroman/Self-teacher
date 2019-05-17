import { withLocalize, LocalizeContextProps } from "react-localize-redux";
import React = require("react");

type Props = LocalizeContextProps & {
    langProps: any
}

const LanguageToggle = (params: Props) =>  (
  <ul className="selector">
    {params.languages.map(lang => (
      <li key={lang.code}>
        <button onClick={() => params.setActiveLanguage(lang.code)}>
          {lang.code}
        </button>
      </li>
    ))}
  </ul>
);

export default withLocalize(LanguageToggle);